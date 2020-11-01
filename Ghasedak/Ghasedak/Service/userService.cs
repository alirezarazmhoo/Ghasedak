using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service
{
    public class userService : IUser
    {
        private Context _context;
        public userService(Context context)
        {
            _context = context;
        }
       
      
        public PagedList<User> GetUsers(int pageId = 1, string filteruserName = "")
        {
            IQueryable<User> result = _context.Users.IgnoreQueryFilters().Where(x=>x.role.RoleNameEn=="Member").OrderByDescending(x=>x.id);
            if(!string.IsNullOrEmpty(filteruserName))
            {
                result = result.Where(x => x.userName.Contains(filteruserName));
            }
            PagedList<User> res = new PagedList<User>(result, pageId, 10);
            return res;
        }
    }
}
