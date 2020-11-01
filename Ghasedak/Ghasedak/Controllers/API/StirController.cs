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

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StirController : ControllerBase
    {
        private readonly Context _context;

        public StirController(Context context)
        {
            _context = context;

        }

        // GET: api/Information
        [HttpGet]

        public object GetStirs()
        {
            var data = new object();
            if( _context.Stirs.Any())
              data=  _context.Stirs.FirstOrDefault();
             if(data==null)
            return new { Data = data,Count=0,IsError=true,Message="نحوه فعالیت ثبت نشده است" };
            else
            return new { Data = data,Count=1,IsError=false,Message="" };
        }
    }
}