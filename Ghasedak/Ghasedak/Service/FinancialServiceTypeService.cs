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
    public class FinancialServiceTypeService : IFinancialServiceType
    {
        private Context _context;
        public FinancialServiceTypeService(Context context)
        {
            _context = context;
        }

        public object GetFinancialServiceType(int charityId)
        {
            IQueryable<FinancialServiceType> result = _context.FinancialServiceTypes.Where(x=>x.charityId==charityId);
            List<FinancialServiceType> res = result.OrderBy(u => u.id).ToList();
            if (res.Count() == 0)
                return new { Data = res, Count = res.Count(), IsError = true, Message = "نوع خدمت ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }

         public int AddFinancialServiceTypeFromAdmin(FinancialServiceType FinancialServiceType)
        {
            _context.FinancialServiceTypes.Add(FinancialServiceType);
            _context.SaveChanges();
            return FinancialServiceType.id;
        }

        

        public PagedList<FinancialServiceType> GetFinancialServiceType(int charityId,int? pageId = 1,string filtertitle="")
        {
            IQueryable<FinancialServiceType> result = _context.FinancialServiceTypes.Where(x=>x.charityId==charityId).OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filtertitle))
            {
                result = result.Where(x => x.title.Contains(filtertitle));
            }
            PagedList<FinancialServiceType> res = new PagedList<FinancialServiceType>(result, Convert.ToInt32(pageId), 10);
            return res;
        }
    }
}
