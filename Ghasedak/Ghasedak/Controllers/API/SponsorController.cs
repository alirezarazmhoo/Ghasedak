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
    public class SponsorController : ControllerBase
    {
        private readonly Context _context;
        private readonly IHostingEnvironment environment;
        private ISponsor _Sponsor;

        public SponsorController(Context context, IHostingEnvironment environment, ISponsor Sponsor)
        {
            this.environment = environment;
            _context = context;
            _Sponsor = Sponsor;

        }


        [HttpGet]
        public object GetSponsor()
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _Sponsor.GetSponsor(oprator.charityId, oprator.id);
            return data;
        }


        [HttpPost]
        public object PostSponsor(IEnumerable<SponsorViewModel> SponsorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return new { IsError = true, message = "ورودی ها معتبر نیست." };
            }
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _Sponsor.AddSponsor(SponsorViewModel,oprator);
            return data;
        }

    }
}