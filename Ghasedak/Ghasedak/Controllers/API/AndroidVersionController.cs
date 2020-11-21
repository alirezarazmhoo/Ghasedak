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
    public class AndroidVersionController : ControllerBase
    {
        private readonly Context _context;

        public AndroidVersionController(Context context)
        {
            _context = context;

        }

         [HttpGet]
        public object GetAndroidVersion()
        {
            var data = new object();
            if( _context.AndroidVersions.Any())
              data=  _context.AndroidVersions.FirstOrDefault();

             if(data==null)
            return new { Data = data,Count=0,IsError=true,Message="ورژن ثبت نشده است" };
            else
            return new { Data = data,Count=1,IsError=false,Message="" };
        }
    }
}