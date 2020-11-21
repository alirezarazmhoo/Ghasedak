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
    public class UserActivityService : IUserActivity
    {
        private Context _context;
        public UserActivityService(Context context)
        {
            _context = context;
        }
        public PagedList<UserActivity> GetUserActivity(int charityId,int pageId = 1)
        {
            IQueryable<UserActivity> result = _context.UserActivities.Include(x=>x.oprator).Where(x=>x.charityId==charityId).OrderByDescending(x => x.id);
            PagedList<UserActivity> res = new PagedList<UserActivity>(result, pageId, 10);
            return res;
        }
    }
}
