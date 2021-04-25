using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.Utility;
using Ghasedak.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly Context _context;

        private IBox _Box;
        private readonly IHostingEnvironment environment;

        public BoxController(Context context, IBox Box, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _Box = Box;

        }

        // GET: api/AllPrices
        [HttpGet]
        public object GetBox()
        {
            string Token = HttpContext.Request?.Headers["token"];
            int charityId = _context.Oprators.FirstOrDefault(x => x.token == Token).charityId;
            var data = _Box.GetBox(charityId);
            return data;
        }

        [HttpPost]
        public object PostBox(IEnumerable<BoxViewModel> Boxs)
        {

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return new { IsError = true, message = "ورودی ها معتبر نیست." };

            }

            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            if (oprator == null)
                return new { IsError = true, message = "چنین کاربری وجود ندارد." };
            var charityActive = _context.Charitys.FirstOrDefault(p => p.id == oprator.charityId);
            if (!oprator.isActive)
                return new { IsError = true, message = "کاربر مورد نظر غیر فعال است." };
            if (!charityActive.isActive)
                return new { IsError = true, message = "خیریه کاربر مورد نظر غیر فعال است." };

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    List<Box> boxUserActivitys = new List<Box>();

                    foreach (var item in Boxs)
                    {

                        var box = new Box();
                        box.number = item.number;
                        box.mobile = item.mobile;
                        box.fullName = item.fullName;
                        box.assignmentDate = item.assignmentDate;
                        box.address = item.address;
                        box.lon = item.lon;
                        box.lat = item.lat;
                        box.charityId = item.charityId;
                        box.opratorId = oprator.id;
                        box.guidBox = item.guidBox;
                        box.boxKind = item.boxKind;
                        box.day = item.day;
                        var DischargeRoute = _context.DischargeRoutes.FirstOrDefault(x => x.guidDischargeRoute == item.guidDischargeRoute);
                        if (DischargeRoute == null)
                            continue;
                        box.dischargeRouteId = DischargeRoute.id;
                        boxUserActivitys.Add(box);
                        _context.Boxs.Add(box);

                    }
                    if (boxUserActivitys == null)
                        return new { IsError = false, message = "تمام صندوق ها قبلا ثبت شده اند." };
                    _context.SaveChanges();
                    foreach (var item in boxUserActivitys)
                    {
                        string json = JsonSerializer.Serialize(item);
                        UserActivityAdd userActivityAdd = new UserActivityAdd(_context);
                        userActivityAdd.Add(item.opratorId, item.charityId, DateTime.Now, UserActivityEnum.register, "صندق با شماره " + item.number + " و شماره همراه " + item.mobile + " ثبت گردید.",json,"Box","Add");
                    }
                    trans.Commit();
                    return new { IsError = false, message = "صندوق ها با موفقیت ثبت گردید." };

                }
                catch (Exception ex)
                {
                    string imageUrl = "a000999.txt";
                    var path2 = Path.Combine(environment.WebRootPath, imageUrl);
                    using (FileStream fs = System.IO.File.Create(path2))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(ex.Message + "\n" + ex.StackTrace + "\n" + ex.InnerException + "\n" + ex.InnerException.InnerException);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                    trans.Rollback();
                }
            }
            return new { IsError = true, message = "ثبت صندوق ها با مشکل مواجه شده است." };

        }


    }
}