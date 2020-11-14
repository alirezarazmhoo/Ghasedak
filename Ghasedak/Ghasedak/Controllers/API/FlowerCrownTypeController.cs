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
    public class FlowerCrownTypeController : ControllerBase
    {
        private readonly Context _context;

        private IFlowerCrownType _FlowerCrownType;
        private readonly IHostingEnvironment environment;

        public FlowerCrownTypeController(Context context, IFlowerCrownType FlowerCrownType, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _FlowerCrownType = FlowerCrownType;

        }

       
        [HttpGet("{charityId}")]
        public object GetFlowerCrownType([FromRoute] int charityId)
        {
            var data = _FlowerCrownType.GetFlowerCrownType(charityId);
            return data;
        }



    }
}