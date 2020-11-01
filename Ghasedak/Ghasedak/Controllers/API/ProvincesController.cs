using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly Context _context;

        private IDischargeRoute _City;

        public ProvincesController(Context context, IDischargeRoute City)
        {
            _context = context;
            _City = City;

        }

        // GET: api/AllPrices
        //[HttpGet("{cityId}")]
        //public object GetProvinces([FromRoute]int cityId)
        //{
        //    var data = _City.GetProvinces(cityId);
        //    return data;
        //}

       
        
    }
}