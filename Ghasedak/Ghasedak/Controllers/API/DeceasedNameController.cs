using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.Utility;
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
        [Route("GetAll")]
        public object GetAll()
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _DeceasedName.GetDeceasedName(oprator.charityId);
            return data;
        }
         [HttpGet]
        [Route("Find")]
        public object Find(string deceasedFullName,string deceaseAalias)
        {
            string Token = HttpContext.Request?.Headers["token"];
            var oprator = _context.Oprators.FirstOrDefault(x => x.token == Token);
            var data = _DeceasedName.SearchDeceasedName(deceasedFullName,deceaseAalias,oprator.charityId);
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
                if (oprator == null)
                    return new { IsError = true, message = "چنین کاربری جود ندارد." };
                
            var charityActive = _context.Charitys.FirstOrDefault(p => p.id==oprator.charityId);
            if (!oprator.isActive )
            
                return new { IsError = true, message = "کاربر مورد نظر غیر فعال است." };
            
            if (!charityActive.isActive )
            
                return new { IsError = true, message = "خیریه کاربر مورد نظر غیر فعال است." };
           
                DeceasedName.charityId = oprator.charityId;
                if (_context.DeceasedNames.Any(x => x.deceaseAalias.Equals(DeceasedName.deceasedFullName)))
                    return new { IsError = true, message = "این متوفی قبلا ثبت شده است." };
                _context.DeceasedNames.Add(DeceasedName);
                _context.SaveChanges();
                string json = JsonSerializer.Serialize(DeceasedName);
                UserActivityAdd userActivityAdd = new UserActivityAdd(_context);

                userActivityAdd.Add(oprator.id, oprator.charityId, DateTime.Now, UserActivityEnum.register, "متوفی با نام و نام خانوادگی " +DeceasedName.deceasedFullName + " ثبت گردید.",json,"DeceasedName","Add");

                return new { IsError = false, message = "متوفی با موفقیت ثبت گردید." };
            }
            catch (Exception ex)
            {
                return new { IsError = true, message = "ثبت متوفی با مشکل مواجه شده است." };
            }
        }

    }
}