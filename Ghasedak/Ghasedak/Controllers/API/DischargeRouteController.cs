using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DischargeRouteController : ControllerBase
    {
        private readonly Context _context;

        private IDischargeRoute _DischargeRoute;

        public DischargeRouteController(Context context, IDischargeRoute DischargeRoute)
        {
            _context = context;
            _DischargeRoute = DischargeRoute;

        }

        // GET: api/AllPrices
        [HttpGet]
        public object GetDischargeRoute()
        {
            string Token = HttpContext.Request?.Headers["token"];
            int opratorId = _context.Oprators.FirstOrDefault(x => x.token == Token).id;
            var data = _DischargeRoute.GetDischargeRoute(opratorId);
            return data;
        }
        [HttpPost]
        public object PostDischargeRoute(IEnumerable<DischargeRoute> dischargeRoutes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
           

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    List<DischargeRoute> DischargeRouteUserActivitys = new List<DischargeRoute>();

                    foreach (DischargeRoute item in dischargeRoutes)
                    {
                        if (_context.DischargeRoutes.Any(x => x.code == item.code))
                            continue;
                        DischargeRouteUserActivitys.Add(item);

                        _context.DischargeRoutes.Add(item);
                    }
                    if(DischargeRouteUserActivitys==null)
                    return new { IsError = false, message = "تمام مسیرها قبلا ثبت شده اند." };
                    _context.SaveChanges();
                    foreach (var item in DischargeRouteUserActivitys)
                    {
                    UserActivityAdd userActivityAdd = new UserActivityAdd(_context);

                        userActivityAdd.Add(oprator.id, oprator.charityId, DateTime.Now, UserActivityEnum.register, "مسیر با کد  " + item.code + " ثبت گردید.");
                    }

                    trans.Commit();
                    return new { IsError = false, message = "مسیر ها با موفقیت ثبت گردید." };

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
            }
            return new { IsError = true, message = "ثبت مسیر ها با مشکل مواجه شده است." };

        }


    }
}