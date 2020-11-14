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
            //var BoxIncomes = _context.BoxIncomes.ToList();
            //List<int> BoxIncomeIds = new List<int>();
            //foreach (var item in BoxIncomes)
            //{
            //    BoxIncomeIds.Add(item.id);
            //}
            //var box = _context.Boxs.Where(x => !BoxIncomeIds.Contains(x.id)).Select(x => new { x.id, x.lon, x.lat });
            //if (res.Count() == 0 && box.Count() == 0)
            //    return new { Data = res, Count = res.Count(), IsError = true, Message = "صندوقی ثبت نشده است" };
            //else
            //    return new { Data = res.Select(x => new { x.id, x.lon, x.lat, x.status, x.boxId, x.registerDate }).GroupBy(x => x.boxId).Select(x => x.Last()), box, Count = res.GroupBy(x => x.boxId).Count(), IsError = false, Message = "" };
            
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
          
            using ( var trans = _context.Database.BeginTransaction())
            {
                try
                {
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
                        var box = _context.Boxs.FirstOrDefault(x => x.number == item.number);
                        if (box == null)
                            continue;
                        BoxIncome.boxId = box.id;
                        _context.BoxIncomes.Add(BoxIncome);
                    }
                    _context.SaveChanges();
                    trans.Commit();
                    //var sherkatName = _context.Settings.FirstOrDefault()?.sherkatName;
                    //foreach (var item in BoxIncomes)
                    //{
                    //    if (item.status != EnumStatus.Absence)
                    //    {
                    //        SmsIrRestfulNetCore.Token tokenInstance = new SmsIrRestfulNetCore.Token();
                    //        var token = tokenInstance.GetToken("ea72b92b8fbd183eccd6c33c", "Ghasedak!!");
                    //        var box = _context.Boxs.FirstOrDefault(x => x.number == item.number);
                    //        var ultraFastSend = new UltraFastSend()
                    //        {
                    //            Mobile = Convert.ToInt64(box.mobile),
                    //            TemplateId = 19650,
                    //            ParameterArray = new List<UltraFastParameters>()
                    //  {
                    //new UltraFastParameters()
                    //      {
                    //      Parameter = "name" , ParameterValue = box.fullName

                    //   },
                    //new UltraFastParameters()
                    //      {
                    //      Parameter = "number" , ParameterValue = box.number

                    //   },
                    //new UltraFastParameters()
                    //      {
                    //      Parameter = "price" , ParameterValue = item.price.ToString()

                    //   },
                    //new UltraFastParameters()
                    //      {
                    //      Parameter = "charityName" , ParameterValue = " "+sherkatName

                    //   }
                    // }.ToArray()

                    //        };

                    //        UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);

                    //        if (ultraFastSendRespone.IsSuccessful == false)
                    //        {
                    //            return new { IsError = false, message = "درآمد با موفقیت ثبت گردید اما پیامک به رستی ارسال نشد." };

                    //        }
                    //    }
                    //}
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

        //[HttpGet]
        //public object GetAllFirstPage()
        //{
        //    var notice = _context.Notices.Where(x => x.expireDate >= DateTime.Now && x.isAdminConfirm).OrderByDescending(x => x.createDate).Take(10).Select(x => new { x.id, x.title, x.description}).ToList();
        //    var noticeIsBarber = _context.Notices.Where(x => x.isBarber && x.expireDate >= DateTime.Now && x.isAdminConfirm).OrderByDescending(x => x.createDate).Take(10).Select(x => new { x.id, x.image1, x.title, x.description, areaName = x.area.name, cityName = x.city.name, provinceName = x.province.name }).ToList();
        //    var noticeIsNotBarber = _context.Notices.Where(x =>  x.expireDate >= DateTime.Now && x.isAdminConfirm).OrderByDescending(x => x.createDate).Take(10).Select(x => new { x.id, x.image1, x.title, x.description, areaName = x.area.name, cityName = x.city.name, provinceName = x.province.name }).ToList();
        //    var slider = _context.Sliders.ToList();
        //    return new { advertismentIsworkshop, advertismentIsNotworkshop, notice, noticeIsBarber, noticeIsNotBarber, slider };

        //}
        // GET: api/Notices
        //[HttpGet("{categoryId}/{page}/{pagesize}")]
        //public object GetNotices([FromRoute]int categoryId,[FromRoute]int page,[FromRoute] int pagesize)
        //{
        //     var data = _notice.GetNotices(categoryId,page,pagesize);
        //    return data;
        //}
        //[HttpGet("{page}/{pagesize}")]
        //public object GetNotices([FromRoute]int page, [FromRoute] int pagesize)
        //{
        //    string Token = HttpContext.Request?.Headers["Token"];
        //    var data = _notice.GetNotices(Token, page, pagesize);
        //    return data;
        //}
        //[HttpGet("{page}/{pagesize}/{isBarber}")]
        //public object GetNotices([FromRoute]int page, [FromRoute] int pagesize)
        //{
        //    IQueryable<Notice> result = _context.Notices.Where(x => x.expireDate >= DateTime.Now && x.isAdminConfirm);
        //    int skip = (page - 1) * pagesize;
        //    var res = result.OrderByDescending(u => u.createDate).Skip(skip).Take(pagesize).Select(x => new { x.id,  x.title, x.description}).ToList();
        //    return new { data = res, totalCount = result.Count() };
        //}
        //[HttpPost("{id}")]
        //public object ExtendedNotice([FromRoute]int id)
        //{
        //    var Notice = _context.Notices.Find(id);
        //    if (Notice == null)
        //        return new { status = 1, message = "چنین درخواستی یافت نشد." };
        //    var setting = _context.Settings.FirstOrDefault();
        //    Notice.expireDate = Notice.expireDate.AddDays(Convert.ToInt64(setting.countExpireDate));
        //    var user = _context.Users.Find(Notice.userId);

        //    _context.SaveChanges();
        //    return new { status = 1, title = "تمدید آگهی", message = "تمدید آگهی با موفقیت انجام شد." };

        //}
        //[HttpPost]
        //public object GetNotices(NoticeSearch NoticeSearch)
        //{
        //    var result = _notice.GetNoticesByCatAndType(NoticeSearch);
        //    return result;
        //}
        //[HttpPost("{page}")]
        //public object GetNotices([FromRoute]int page)
        //{
        //    var data = _notice.GetLastNotices(page);
        //    return data;
        //}

        // GET: api/Notices/5
        //[HttpGet("{id}")]
        //public object GetNotice([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var Notice = _context.Notices.Find(id);
        //    Notice.countView = Notice.countView + 1;
        //    var images = _context.NoticeImages.Where(p => p.noticeId == id).Select(p => new { p.image }).ToList();
        //    var visitNotice = _context.VisitNotices.FirstOrDefault(x => x.noticeId == id && DateTime.Compare(x.date.Date, DateTime.Now.Date) == 0);
        //    if (visitNotice != null)
        //        visitNotice.countView++;
        //    else
        //    {
        //        _context.VisitNotices.Add(new VisitNotice { countView = 1, date = DateTime.Now, noticeId = id });
        //    }
        //    _context.SaveChanges();
        //    if (Notice == null)
        //    {
        //        return NotFound();
        //    }

        //    return new { Notice = _context.Notices.Select(p => new { p.id, p.countView, areaName = p.area.name, provinceName = p.province.name, cityName = p.city.name, p.code, createDate=DateToUnix(p.createDate), p.description, categoryName = p.category.name, p.totallDescription, p.title, p.price, p.movie, p.image, p.isSpecial, p.lastPrice, dailyVisit = DailyVisit(p.id) }).FirstOrDefault(x => x.id == id), images };

        //}
        //private object DailyVisit(int noticeId)
        //{
        //    var visitNotice = _context.VisitNotices.Where(x => x.noticeId == noticeId).OrderByDescending(x => x.id).Select(x => new { x.id, x.countView, date = DateToUnix(x.date)/*, date1 = Convert.ToInt32(DateTime.UtcNow.Subtract(x.date).TotalSeconds)*/ });
        //    var dailyVisitNotice = visitNotice.Take(7);
        //    //var monthlyVisitNotice = visitNotice.GroupBy(x => x.date.Month).ToList();
        //    //foreach (var item in visitNotice)
        //    //{

        //    //}
        //    return dailyVisitNotice;

        //}
        public long DateToUnix(DateTime date)
        {
            date.AddHours(-3);
            date.AddMinutes(-30);
            TimeSpan timeSpan = date - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)timeSpan.TotalSeconds;
        }

        //[HttpPost]
        //public object PostNotice()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    BoxIncome notice = new BoxIncome();

        //    try
        //    {
        //        string Token = HttpContext.Request?.Headers["Token"];
        //        var user = _context.Users.Where(p => p.token == Token).FirstOrDefault();
        //        if (user == null)
        //            return new { status = 3, message = "چنین کاربری وجود ندارد." };

        //        //string title = HttpContext.Request?.Form["title"];
        //        //string description = HttpContext.Request?.Form["description"];

        //        //bool isBarber =Convert.ToBoolean(HttpContext.Request?.Form["isBarber"]);
        //        //int cityId =Convert.ToInt32(HttpContext.Request?.Form["cityId"]);
        //        //int provinceId =Convert.ToInt32(HttpContext.Request?.Form["provinceId"]);
        //        //int areaId =Convert.ToInt32(HttpContext.Request?.Form["areaId"]);

        //        string data = HttpContext.Request?.Form["data"];

        //        JObject json = JObject.Parse(data);
        //        JObject jalbum = json as JObject;
        //        var movie = "";
        //        BoxIncome noticedata = jalbum.ToObject<BoxIncome>();
        //        string imageUrl = "";
        //        var setting = _context.Settings.FirstOrDefault();

        //        notice.title = noticedata.title;
        //        notice.lastPrice = noticedata.lastPrice;
        //        notice.cityId = noticedata.cityId;
        //        notice.provinceId = noticedata.provinceId;
        //        notice.price = noticedata.price;
        //        notice.totallDescription = noticedata.totallDescription;
        //        notice.description = noticedata.description;
        //        notice.createDate = DateTime.Now;
        //        notice.expireDateIsespacial = DateTime.Now;
        //        notice.expireDate = DateTime.Now.AddDays(Convert.ToInt64(setting.countExpireDate));
        //        notice.adminConfirmStatus = EnumStatus.Pending;
        //        notice.userId = user.id;
        //        if (_context.Notices.Count() == 0)
        //            notice.code = "1";
        //        else
        //            notice.code = (Convert.ToInt32(_context.Notices.LastOrDefault().code) + 1).ToString();
        //        var httpRequest = HttpContext.Request;
        //        var hfc = HttpContext.Request.Form.Files;
        //        List<string> images = new List<string>();
        //        for (int i = 0; i < hfc.Count; i++)
        //        {
        //            if (hfc[i].Length > 1024 * 1024 * 10)
        //            {
        //                return new { status = 1, message = "فایل ارسالی بزرگ تر از حد مجاز می باشد." };
        //            }
        //            else
        //            {
        //                var namefile = Guid.NewGuid().ToString().Replace('-', '0').Substring(0, 7) + Path.GetExtension(hfc[i].FileName).ToLower();
        //                var filePath = Path.Combine(environment.WebRootPath, "Notice/", namefile);

        //                if (hfc[i].Name == "imageUrl")
        //                {
        //                    imageUrl = "/Notice/" + namefile;
        //                }


        //                else if (hfc[i].Name == "movie")
        //                {
        //                    movie = "/Notice/" + namefile;
        //                }

        //                else
        //                {

        //                    images.Add("/Notice/" + namefile);

        //                }
        //                using (var stream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    hfc[i].CopyTo(stream);
        //                }
        //            }
        //        }
        //        notice.movie = movie;
        //        notice.image = imageUrl;
        //        _context.Notices.Add(notice);

        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new { status = 2, title = "خطا در ثبت آگهی", message = "آگهی شما ثبت نشد." };

        //    }
        //    return new { noticeId = notice.id, status = 1, title = "ثبت آگهی", message = "آگهی شما با موفقیت ثبت گردید." };
        //}
        //[HttpPut("{id}")]
        //public object PutNotice([FromRoute]int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    string Token = HttpContext.Request?.Headers["Token"];
        //    var user = _context.Users.Where(p => p.token == Token).FirstOrDefault();
        //    if (user == null)
        //        return new { status = 3, message = "چنین کاربری وجود ندارد." };
        //    string data = HttpContext.Request?.Form["data"];
        //    JObject json = JObject.Parse(data);
        //    JObject jalbum = json as JObject;
        //    var movie = "";
        //    string imageUrl = "";

        //    BoxIncome Notice = jalbum.ToObject<BoxIncome>();
        //    var notice = _context.Notices.Find(id);
        //    var httpRequest = HttpContext.Request;
        //    var hfc = HttpContext.Request.Form.Files;
        //    List<string> images = new List<string>();
        //    for (int i = 0; i < hfc.Count; i++)
        //    {
        //        if (hfc[i].Length > 1024 * 1024 * 10)
        //        {
        //            return new { status = 1, message = "فایل ارسالی بزرگ تر از حد مجاز می باشد." };
        //        }
        //        else
        //        {
        //            var namefile = Guid.NewGuid().ToString().Replace('-', '0').Substring(0, 7) + Path.GetExtension(hfc[i].FileName).ToLower();
        //            var filePath = Path.Combine(environment.WebRootPath, "Notice/", namefile);
        //            if (hfc[i].Name == HttpContext.Request.Form.Files["imageUrl"].Name)
        //            {
        //                imageUrl = "/Notice/" + namefile;
        //            }
        //            if (hfc[i].Name == HttpContext.Request.Form.Files["movie"].Name)
        //            {
        //                movie = "/Notice/" + namefile;
        //            }
        //            else
        //            {

        //                images.Add("/Notice/" + namefile);

        //            }
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                hfc[i].CopyTo(stream);
        //            }
        //        }
        //    }
        //    if (movie != "")
        //        notice.movie = movie;
        //    if (imageUrl != "")
        //        notice.image = imageUrl;




        //    notice.title = Notice.title;

        //    notice.description = Notice.description;

        //    notice.cityId = Notice.cityId;

        //    notice.provinceId = Notice.provinceId;


        //    notice.lastPrice = Notice.lastPrice;

        //    notice.price = Notice.price;

        //    notice.totallDescription = Notice.totallDescription;

        //    _context.Notices.Update(notice);
        //    _context.SaveChanges();
        //    return new { status = 0, message = "آگهی شما با موفقیت ویرایش گردید." };
        //}

    }
}