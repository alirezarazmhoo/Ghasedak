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
    public class AboutUsController : ControllerBase
    {
        private readonly Context _context;

        public AboutUsController(Context context)
        {
            _context = context;

        }

        // GET: api/Information
        [HttpGet]

        public object GetAboutUss()
        {
            var data = new object();
            if( _context.AboutUss.Any())
              data=  _context.AboutUss.FirstOrDefault();
             if(data==null)
            return new { Data = data,Count=0,IsError=true,Message="درباره ما ثبت نشده است" };
            else
            return new { Data = data,Count=1,IsError=false,Message="" };
        }
    }
}