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
    public class DonatorController : ControllerBase
    {
        private readonly Context _context;

        private IDonator _Donator;
        private readonly IHostingEnvironment environment;

        public DonatorController(Context context, IDonator Donator, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _Donator = Donator;

        }


        [HttpGet]
        public object GetDonator()
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _Donator.GetDonator(oprator.charityId);
            return data;
        }
        [HttpPost]
        public object PostDonator(Donator Donator)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string Token = HttpContext.Request?.Headers["token"];
                var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
                Donator.charityId = oprator.charityId;
                if (_context.Donators.Any(x => x.donatorMobile == Donator.donatorMobile && x.donatorAlias.Equals(Donator.donatorAlias)))
                    return new { IsError = true, message = "ثبت اهدا کننده با مشکل مواجه شده است." };
                _context.Donators.Add(Donator);
                _context.SaveChanges();
                return new { IsError = false, message = "اهدا کننده با موفقیت ثبت گردید." };
            }
            catch (Exception ex)
            {
                return new { IsError = true, message = "ثبت متوفی با مشکل مواجه شده است." };
            }
        }


    }
}