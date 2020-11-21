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
    public class FlowerCrownController : ControllerBase
    {
        private readonly Context _context;

        private IFlowerCrown _FlowerCrown;
        private readonly IHostingEnvironment environment;

        public FlowerCrownController(Context context, IFlowerCrown FlowerCrown, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _FlowerCrown = FlowerCrown;

        }

        
        [HttpGet]
        public object GetFlowerCrown()
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _FlowerCrown.GetFlowerCrown(oprator.charityId);
            return data;
        }
        [HttpPost]
        public object PostFlowerCrown(FlowerCrown FlowerCrown)
        {
            if (!ModelState.IsValid)
            {
                return new { IsError = true, message = "ورودی ها معتبر نیست." };
            }
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
             if (oprator == null)
                return new { IsError = true, message = "چنین کاربری وجود ندارد." };
            var charityActive = _context.Charitys.FirstOrDefault(p => p.id==oprator.charityId);
            if (!oprator.isActive )
                return new { IsError = true, message = "کاربر مورد نظر غیر فعال است." };
            if (!charityActive.isActive )
                return new { IsError = true, message = "خیریه کاربر مورد نظر غیر فعال است." };
            var data = _FlowerCrown.AddFlowerCrown(FlowerCrown,oprator);
            return data;
            
           
        }
       

    }
}