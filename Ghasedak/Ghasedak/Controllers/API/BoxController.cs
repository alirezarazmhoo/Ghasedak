using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
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
            var data = _Box.GetBox();
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
            

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
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
                        //var dischargeRoute = _context.DischargeRoutes.FirstOrDefault(x => x.code == item.code);
                        if (!_context.DischargeRoutes.Any(x => x.id == item.dischargeRouteId))
                            continue;
                        box.dischargeRouteId = item.dischargeRouteId;
                        _context.Boxs.Add(box);

                    }
                    _context.SaveChanges();
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