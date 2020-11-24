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
    public class charityService : ICharity
    {
        private Context _context;
        public charityService(Context context)
        {
            _context = context;
        }
       
      
        public PagedList<Charity> GetCharity(int pageId = 1, string filtercode = "")
        {
            IQueryable<Charity> result = _context.Charitys.IgnoreQueryFilters().OrderByDescending(x=>x.id);
            if(!string.IsNullOrEmpty(filtercode))
            {
                result = result.Where(x => x.code.Contains(filtercode));
            }
            PagedList<Charity> res = new PagedList<Charity>(result, pageId, 10);
            return res;
        }
        public async Task<object> GetCharityAsync( int chrityId)
        {
            var data= await _context.Charitys.Select(x => new { x.isActive,x.isAccessBox,x.isAccessFinancialAid,x.isAccessFlowerCrown,x.isAccessSponsor,x.id }).FirstOrDefaultAsync(x=>x.id==chrityId);
            return data;
        }
        public async Task<bool> ActiveCharityAsync( int chrityId,string code)
        {
            var data= await _context.Charitys.FirstOrDefaultAsync(x=>x.id==chrityId);
            if (data.androidCode == code)
            {
                data.isActive = true;
               await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}
