using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.ViewModel;
using Microsoft.EntityFrameworkCore;
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



        public PagedList<FinancialAid> GetFinancialAidFromAdmin(int charityId,int pageId = 1, string filtername = "")
        {
            IQueryable<FinancialAid> result = _context.FinancialAids.Include(x=>x.FinancialServiceType).Where(x=>x.charityId==charityId).OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filtername))
            {
                result = result.Where(x => x.name.Contains(filtername));
            }
            PagedList<FinancialAid> res = new PagedList<FinancialAid>(result, pageId, 10);
            return res;
        }
          public FinancialAidAdminViewModel GetDataForAdmin(int id)
        {
            var FinancialAid = _context.FinancialAids.Include(x => x.FinancialServiceType).FirstOrDefault(x => x.id == id);
            var oprator = _context.Oprators.FirstOrDefault(x => x.id ==FinancialAid.opratorId);
            FinancialAidAdminViewModel FinancialAidAdminViewModel = new FinancialAidAdminViewModel();
            FinancialAidAdminViewModel.financialAid = FinancialAid;
            FinancialAidAdminViewModel.oprator = oprator;
            return FinancialAidAdminViewModel;
        }
        
    }
}
