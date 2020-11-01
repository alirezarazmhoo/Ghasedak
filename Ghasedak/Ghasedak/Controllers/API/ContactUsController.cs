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
    public class ContactUsController : ControllerBase
    {
        private readonly Context _context;

        public ContactUsController(Context context)
        {
            _context = context;
        }
       
        [HttpGet]

        public object GetContactUss()
        {
            var data = new object();
            if( _context.ContactUss.Any())
              data=  _context.ContactUss.FirstOrDefault();
            if(data==null)
            return new { Data = data,Count=0,IsError=true,Message="تماس با ما ثبت نشده است" };
            else
            return new { Data = data,Count=1,IsError=false,Message="" };
            
        }
    }
}