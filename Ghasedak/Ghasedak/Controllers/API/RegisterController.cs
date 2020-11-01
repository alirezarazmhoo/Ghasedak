using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmsIrRestfulNetCore;

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly Context _context;

        public RegisterController(Context context)
        {
            _context = context;
        }
        [HttpPost]

        public object Register(LoginUser user1)
        {

            //send sms
           
            var user = new User();
            Random random = new Random();
            if (_context.Users.Any(p => p.userName == user1.userName))
            {
                user = _context.Users.IgnoreQueryFilters().FirstOrDefault(p => p.userName == user1.userName);
                user.code = random.Next(100000, 999999).ToString();
               
                return new { status = 1, title = "کد تایید", message = "کد تایید شما ارسال شد", code = user.code };
            }
            user.token = Guid.NewGuid().ToString().Replace('-', '0');
            user.userName = user1.userName;
            user.code = random.Next(100000, 999999).ToString();
            Role r = _context.Roles.Where(p => p.RoleNameEn == "Member").FirstOrDefault();
            user.role = r;
            _context.Users.Add(user);
           
             return new { status = 1, title = "کد تایید", message = "کد تایید شما ارسال شد", code = user.code };
        }


    }
}