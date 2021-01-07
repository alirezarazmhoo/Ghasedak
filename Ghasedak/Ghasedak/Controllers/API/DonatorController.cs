using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        [Route("GetAll")]

        public object GetDonator()
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _Donator.GetDonator(oprator.charityId);
            return data;
        }
        [HttpGet]
        [Route("Find")]

        public object Find(string donatorFullName,string donatorAlias,string donatorMobile)
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _Donator.SearchDonator(donatorFullName,donatorAlias,donatorMobile,oprator.charityId);
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
                if (oprator == null)
                    return new { IsError = true, message = "چنین کاربری وجود ندارد." };
                var charityActive = _context.Charitys.FirstOrDefault(p => p.id == oprator.charityId);
                if (!oprator.isActive)
                    return new { IsError = true, message = "کاربر مورد نظر غیر فعال است." };
                if (!charityActive.isActive)
                    return new { IsError = true, message = "خیریه کاربر مورد نظر غیر فعال است." };
                Donator.charityId = oprator.charityId;
                if (_context.Donators.Any(x => x.donatorMobile == Donator.donatorMobile && x.donatorAlias.Equals(Donator.donatorAlias)))
                    return new { IsError = true, message = "اهدا کننده قبلا ثبت شده است." };
                _context.Donators.Add(Donator);
                _context.SaveChanges();
                UserActivityAdd userActivityAdd = new UserActivityAdd(_context);
                userActivityAdd.Add(oprator.id, oprator.charityId, DateTime.Now, UserActivityEnum.register, "اهدا کننده  " + Donator.donatorFullName + " ثبت گردید.");

                return new { IsError = false, message = "اهدا کننده با موفقیت ثبت گردید." };
            }
            catch (Exception ex)
            {
                return new { IsError = true, message = "ثبت اهدا کننده با مشکل مواجه شده است." };
            }
        }


    }
}