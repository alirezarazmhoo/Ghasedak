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
    public class DonatorService : IDonator
    {
        private Context _context;
        public DonatorService(Context context)
        {
            _context = context;
        }

        public object GetDonator(int charityId)
        {
            IQueryable<Donator> result = _context.Donators.Where(x=>x.charityId==charityId);
            List<Donator> res = result.OrderBy(u => u.id).ToList();
            if (res.Count() == 0)
                return new { Data = res, Count = res.Count(), IsError = true, Message = "اهدا کننده ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }

         public int AddDonatorFromAdmin(Donator Donator)
        {
            _context.Donators.Add(Donator);
            _context.SaveChanges();
            return Donator.id;
        }

        

        public PagedList<Donator> GetDonator(int charityId,int? pageId = 1,string filterfullName="")
        {
            IQueryable<Donator> result = _context.Donators.OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filterfullName))
            {
                result = result.Where(x => x.donatorFullName.Contains(filterfullName));
            }
            PagedList<Donator> res = new PagedList<Donator>(result, Convert.ToInt32(pageId), 10);
            return res;
        }
    }
}
