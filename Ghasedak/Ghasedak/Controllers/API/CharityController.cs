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
    public class CharityController : ControllerBase
    {
        private readonly Context _context;

        private ICharity _Charity;
        private readonly IHostingEnvironment environment;

        public CharityController(Context context, ICharity Charity, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _Charity = Charity;

        }

        [HttpGet]
        public async Task<object> Get()
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            if(oprator==null)
             return new { IsError = true, message = "چنین کاربری وجود ندارد." };
            var data = _Charity.GetCharityAsync(oprator.charityId);
            return await data;
        }

       

    }
}