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
    [Produces("application/json")]
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
        [Route("GetAll")]
        public object GetAll(int page)
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _FlowerCrown.GetFlowerCrownApi(oprator.charityId,page);
            return data;        }
        [HttpPost]
        public object PostFlowerCrown(FlowerCrownViewModelApi FlowerCrownViewModelApi)
        {
            if (!ModelState.IsValid)
            {
                return new { IsError = true, message = "ورودی ها معتبر نیست." };
            }
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            if (oprator == null)
                return new { IsError = true, message = "چنین کاربری وجود ندارد." };
            var charityActive = _context.Charitys.FirstOrDefault(p => p.id == oprator.charityId);
            if (!oprator.isActive)
                return new { IsError = true, message = "کاربر مورد نظر غیر فعال است." };
            if (!charityActive.isActive)
                return new { IsError = true, message = "خیریه کاربر مورد نظر غیر فعال است." };
            var data = _FlowerCrown.AddFlowerCrown(FlowerCrownViewModelApi, oprator);
            return data;


        }
        [HttpGet]
        [Route("Find")]
        public object Find( string donatorName, string deceasedName,string introducedName,long? price,int? ceremonyType,int? flowerCrownTypeId,int page=1)
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _FlowerCrown.SearchFlowerCrown(donatorName,deceasedName,introducedName,price,ceremonyType,flowerCrownTypeId,oprator.charityId,page);
            return data;
        }
    }
}