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
    public class FinancialAidController : ControllerBase
    {
        private readonly Context _context;
        private readonly IHostingEnvironment environment;
        private IFinancialAid _FinancialAid;

        public FinancialAidController(Context context, IHostingEnvironment environment,IFinancialAid FinancialAid)
        {
            this.environment = environment;
            _context = context;
            _FinancialAid = FinancialAid;

        }


        [HttpGet]
        public object GetFinancialAid()
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _FinancialAid.GetFinancialAid(oprator.id, oprator.charityId);
            return data;
        }


        [HttpPost]
        public object PostFinancialAid(IEnumerable<FinancialAid> FinancialAids)
        {
            if (!ModelState.IsValid)
            {
                return new { IsError = true, message = "ورودی ها معتبر نیست." };
            }
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in FinancialAids)
                    {
                        var FinancialAid = new FinancialAid();
                        FinancialAid.financialServiceTypeId = item.financialServiceTypeId;
                        FinancialAid.name = item.name;
                        FinancialAid.price = item.price;
                        FinancialAid.charityId = oprator.charityId;
                        FinancialAid.opratorId = oprator.id;
                        if (item.id!=0)
                            continue;
                        _context.FinancialAids.Add(FinancialAid);
                    }
                    _context.SaveChanges();
                    trans.Commit();
                    return new { IsError = false, message = "کمک های نقدی با موفقیت ثبت گردید." };
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
            }
            return new { IsError = true, message = "درج کمک های نقدی با مشکل مواجه شده است." };

        }
       



    }
}