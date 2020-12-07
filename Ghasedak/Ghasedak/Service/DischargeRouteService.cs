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
    public class DischargeRouteService : IDischargeRoute
    {
        private Context _context;
        public DischargeRouteService(Context context)
        {
            _context = context;
        }

        public object GetDischargeRoute(int charityId)
        {

            IQueryable<DischargeRoute> result = _context.DischargeRoutes.Where(x=>x.charityId==charityId);

            List<DischargeRoute> res = result.OrderBy(u => u.id).ToList();
            if (res.Count() == 0)
                return new { Data = res, Count = res.Count(), IsError = true, Message = "مسیری ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }
        //public object GetCities()
        //{
        //    IQueryable<DischargeRoute> result = _context.Cities;
        //    List<DischargeRoute> res = result.OrderBy(u => u.id).ToList();
        //    return new { data = res, totalCount = result.Count() };
        //}
        // public object GetProvinces(int cityId)
        //{
        //    IQueryable<Box> result = _context.Provinces;
        //    object res = result.Where(x=>x.cityId==cityId).OrderBy(u => u.id).Select( x=>new {x.id,x.name }).ToList();
        //    return new { data = res, totalCount = result.Count() };
        //}

        public PagedList<DischargeRoute> GetDischargeRoute(int charityId,int pageId = 1, string filtercode = "")
        {
            IQueryable<DischargeRoute> result = _context.DischargeRoutes.Where(x=>x.charityId==charityId).OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filtercode))
            {
                result = result.Where(x => x.code.Contains(filtercode));
            }
            PagedList<DischargeRoute> res = new PagedList<DischargeRoute>(result, pageId, 10);
            return res;
        }
    }
}
