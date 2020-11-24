using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.ViewModel;
using SmsIrRestfulNetCore;

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasswordController : ControllerBase
    {
        private readonly Context _context;

        public ForgetPasswordController(Context context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpPost]
        public object GetUser(ForgetUser user1)
        {

            // string cellphone = HttpContext.Request?.Headers["cellphone"];
            if (!_context.Users.Any(p => p.userName == user1.userName))
            {
                return new { IsError = true, message = "این شماره قبلا ثبت نشده است لطفا با ادمین تماس بگیرید." };
            }
            else
            {
                var user = _context.Oprators.Where(p => p.userName == user1.userName).FirstOrDefault();
                //send sms
                SmsIrRestfulNetCore.Token tokenInstance = new SmsIrRestfulNetCore.Token();
                var token = tokenInstance.GetToken("ea72b92b8fbd183eccd6c33c", "Ghasedak!!");
                var ultraFastSend = new UltraFastSend()
                {
                    Mobile = Convert.ToInt64(user1.userName),
                    TemplateId = 19234,
                    ParameterArray = new List<UltraFastParameters>()
                      {
                    new UltraFastParameters()
                          {
                          Parameter = "VerificationCode" , ParameterValue = user.passwordShow

                       }
                     }.ToArray()

                };

                UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);

                if (ultraFastSendRespone.IsSuccessful == false)
                {
                    return new { IsError = true, message = "خطا در ارسال پیامک." };

                }
                return new { IsError = false, message = "پیامک با موفقیت ارسال شد." };
            }

        }

    }
}