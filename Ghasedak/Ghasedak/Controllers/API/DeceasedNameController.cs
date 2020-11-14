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
    public class DeceasedNameController : ControllerBase
    {
        private readonly Context _context;

        private IDeceasedName _DeceasedName;
        private readonly IHostingEnvironment environment;

        public DeceasedNameController(Context context, IDeceasedName DeceasedName, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _DeceasedName = DeceasedName;

        }


        [HttpGet]
        public object GetDeceasedName()
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _DeceasedName.GetDeceasedName(oprator.charityId);
            return data;
        }
        [HttpPost]
        public object PostDeceasedName(DeceasedName DeceasedName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            DeceasedName.charityId = oprator.charityId;
                if (_context.DeceasedNames.Any(x => x.deceaseAalias.Equals(DeceasedName.deceasedFullName)))
                    return new { IsError = true, message = "ثبت متوفی با مشکل مواجه شده است." };
                _context.DeceasedNames.Add(DeceasedName);
                _context.SaveChanges();
                return new { IsError = false, message = "متوفی با موفقیت ثبت گردید." };
            }
            catch (Exception ex)
            {
                return new { IsError = true, message = "ثبت متوفی با مشکل مواجه شده است." };
            }
        }

    }
}