using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service
{
    public class FinancialAidService : IFinancialAid
    {
        private Context _context;
        public FinancialAidService(Context context)
        {
            _context = context;
        }

        public object GetFinancialAid(int opratorId,int charityId)
        {
            IQueryable<FinancialAid> result = _context.FinancialAids.Where(x=>x.charityId==charityId && x.opratorId==opratorId);
            
            var res = result.OrderByDescending(u => u.id).ToList();
            if (res.Count() == 0)
            
                return new { Data = res, Count = res.Count(), IsError = true, Message = "تاج گل ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }

         public int AddFinancialAidFromAdmin(FinancialAid FinancialAid)
        {
            _context.FinancialAids.Add(FinancialAid);
            _context.SaveChanges();
            return FinancialAid.id;
        }



        public PagedList<FinancialAid> GetFinancialAid(int pageId = 1, string filternumber = "")
        {
            IQueryable<FinancialAid> result = _context.FinancialAids.OrderByDescending(x => x.id);
            //if (!string.IsNullOrEmpty(filternumber))
            //{
            //    result = result.Where(x => x.number.Contains(filternumber));
            //}
            PagedList<FinancialAid> res = new PagedList<FinancialAid>(result, pageId, 10);
            return res;
        }

        
    }
}
