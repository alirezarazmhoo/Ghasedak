using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Newtonsoft.Json.Linq;
using Ghasedak.Utility;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Ghasedak.ViewModel;
using SmsIrRestfulNetCore;
using System.Text;

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxIncomeController : ControllerBase
    {
        private readonly Context _context;
        private readonly IHostingEnvironment environment;

        public BoxIncomeController(Context context, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;

        }
        [HttpGet]
        public object GetBoxIncome()
        {
            string Token = HttpContext.Request?.Headers["token"];
            int opratorId = _context.Oprators.FirstOrDefault(x => x.token == Token).id;
            
            IQueryable<BoxIncome> result = _context.BoxIncomes.Where(x=>x.opratorId==opratorId);
            List<BoxIncome> res = result.OrderBy(u => u.id).ToList();
           
            if (res.Count() == 0)
                return new { Data = res, Count = res.Count(), IsError = true, Message = "درآمد ثبت نشده است" };
            else
               return new { Data = res.Select(x => new { x.id, x.lon, x.lat, x.status, x.boxId, x.registerDate }).GroupBy(x => x.boxId).Select(x => x.Last()), Count = res.Count(), IsError = false, Message = "" };

        }
        [HttpPost]
        public object PostBoxIncome(IEnumerable<BoxIncomeViewModel> BoxIncomes)
        {
            if (!ModelState.IsValid)
            {
                return new { IsError = true, message = "ورودی ها معتبر نیست." };

                //return BadRequest(ModelState);
            }
            string Token = HttpContext.Request?.Headers["Token"];
            var oprator = _context.Oprators.Where(p => p.token == Token).FirstOrDefault();
             if (oprator == null)
                return new { IsError = true, message = "چنین کاربری وجود ندارد." };
            var charityActive = _context.Charitys.FirstOrDefault(p => p.id==oprator.charityId);
            if (!oprator.isActive )
                return new { IsError = true, message = "کاربر مورد نظر غیر فعال است." };
            if (!charityActive.isActive )
                return new { IsError = true, message = "خیریه کاربر مورد نظر غیر فعال است." };
            
            using ( var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    List<BoxIncome> boxIncomeUserActivitys = new List<BoxIncome>();

                    foreach (var item in BoxIncomes)
                    {
                        var BoxIncome = new BoxIncome();
                        BoxIncome.lat = item.lat;
                        BoxIncome.lon = item.lon;
                        BoxIncome.price = item.price;
                        BoxIncome.status = item.status;
                        BoxIncome.opratorId = oprator.id;
                        BoxIncome.charityId = item.charityId;
                        BoxIncome.registerDate = item.assignmentDate;
                        var Box = _context.Boxs.FirstOrDefault(x => x.guidBox == item.guidBox);
                        if (Box == null)
                            continue;
                        BoxIncome.boxId = Box.id;
                        boxIncomeUserActivitys.Add(BoxIncome);
                        _context.BoxIncomes.Add(BoxIncome);
                    }
                     if(boxIncomeUserActivitys==null)
                    return new { IsError = false, message = "تمام درآمدها قبلا ثبت شده اند." };
                    _context.SaveChanges();
                    foreach (var item in boxIncomeUserActivitys)
                    {
                         UserActivityAdd userActivityAdd = new UserActivityAdd(_context);

                        userActivityAdd.Add(item.opratorId, item.charityId, DateTime.Now, UserActivityEnum.register, "درآمد با قیمت " + item.price + " ثبت گردید.");
                    }
                    trans.Commit();
                   
                    return new { IsError = false, message = "درآمد ها با موفقیت ثبت گردید." };

                }
                catch (Exception ex)
                {
                    string imageUrl = "aBoxIncome.txt";
                    var path2 = Path.Combine(environment.WebRootPath, imageUrl);
                    using (FileStream fs = System.IO.File.Create(path2))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(ex.Message + "\n" + ex.StackTrace + "\n" + ex.InnerException + "\n" + ex.InnerException.InnerException);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                    trans.Rollback();
                    return new { IsError = true, message = "خطای سیستمی رخ داده است." };

                }

            }

        }

        
        public long DateToUnix(DateTime date)
        {
            date.AddHours(-3);
            date.AddMinutes(-30);
            TimeSpan timeSpan = date - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)timeSpan.TotalSeconds;
        }

        

    }
}