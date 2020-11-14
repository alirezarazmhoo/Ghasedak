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
    public class BoxIncomeService : IBoxIncome
    {
        private Context _context;
        public BoxIncomeService(Context context)
        {
            _context = context;
        }
        public PagedList<BoxIncome> GetBoxIncome(int charityId,int pageId = 1)
        {
            IQueryable<BoxIncome> result = _context.BoxIncomes.Where(x=>x.charityId==charityId).Include(x=>x.oprator).Include(x=>x.box).OrderByDescending(x => x.id);
           
            PagedList<BoxIncome> res = new PagedList<BoxIncome>(result, pageId, 10);
            return res;
        }
    }
}
