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
    public class OpratorService : IOprator
    {
        private Context _context;
        public OpratorService(Context context)
        {
            _context = context;
        }
       
      
        public PagedList<Oprator> GetOprators(int charityId,int pageId = 1, string filteruserName = "")
        {
            IQueryable<Oprator> result = _context.Oprators.Where(x=>x.charityId==charityId).OrderByDescending(x=>x.id);
            if(!string.IsNullOrEmpty(filteruserName))
            {
                result = result.Where(x => x.userName.Contains(filteruserName));
            }
            PagedList<Oprator> res = new PagedList<Oprator>(result, pageId, 10);
            return res;
        }
    }
}
