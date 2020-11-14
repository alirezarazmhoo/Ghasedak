using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
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


            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (DischargeRoute item in dischargeRoutes)
                    {
                        if (_context.DischargeRoutes.Any(x => x.code == item.code))
                                    continue;
                        _context.DischargeRoutes.Add(item);
                    }
                    _context.SaveChanges();
                    trans.Commit();
                    return new { IsError = false, message = "مسیر ها با موفقیت ثبت گردید." };

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
            }
                return new { IsError=true, message = "ثبت مسیر ها با مشکل مواجه شده است." };
           
        }


    }
}