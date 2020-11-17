using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }
        //[HttpPost]

        //public object Login(RegisterUser user)
        //{
        //    var data = _context.Users.Where(p => p.role.RoleNameEn == "Member").FirstOrDefault(p => p.userName == user.userName);
        //    if (data == null)
        //    {
        //        return new { IsError = true, message = "چنین کاربری وجود ندارد." };
        //    }

        //    if (!BCrypt.Net.BCrypt.Verify(user.password, data.password))
        //        return new { IsError = true, message = "خطای ورود." };
        //    return new { IsError = false, message = "", token = data.token, fullName = data.fullName, code = data.code };
        //}

        [HttpPost]

        public object Login(RegisterUser user)
        {
            var oprator = _context.Oprators.FirstOrDefault(p => p.userName == user.userName);
            if (oprator == null)
            {
                return new { IsError = true, message = "چنین کاربری وجود ندارد." };
            }
            var charityActive = _context.Charitys.FirstOrDefault(p => p.id==oprator.charityId);
            if (!oprator.isActive )
            {
                return new { IsError = true, message = "کاربر مورد نظر غیر فعال است." };
            }
            if (!charityActive.isActive )
            {
                return new { IsError = true, message = "خیریه کاربر مورد نظر غیر فعال است." };
            }

            if (!BCrypt.Net.BCrypt.Verify(user.password, oprator.password))
                return new { IsError = true, message = "خطای ورود." };
            return new { IsError = false, message = "", token = oprator.token, fullName = oprator.fullName, code = oprator.code,charityId=oprator.charityId };
        }

    }
}