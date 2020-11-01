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

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxNotEmptyController : ControllerBase
    {
        private readonly Context _context;
        private readonly IHostingEnvironment environment;

        public BoxNotEmptyController(Context context, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;

        }
        [HttpGet]
        public object GetBoxIncome()
        {
            IQueryable<BoxIncome> result = _context.BoxIncomes;
            var BoxIncomes = result.ToList();
            List<int> BoxIncomeIds = new List<int>();
            foreach (var item in BoxIncomes)
            {
                BoxIncomeIds.Add(item.id);
            }
            var box = _context.Boxs.Where(x => !BoxIncomeIds.Contains(x.id)).Select(x => new { x.id, x.lon, x.lat });
            if (box.Count() == 0)
                return new { Data = box, Count = box.Count(), IsError = true, Message = "صندوقی ثبت نشده است" };
            else
                return new { Data =  box, Count = box.Count(), IsError = false, Message = "" };
        }
       

    }
}