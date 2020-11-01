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
    public class BoxService : IBox
    {
        private Context _context;
        public BoxService(Context context)
        {
            _context = context;
        }

        public object GetBox()
        {
            IQueryable<Box> result = _context.Boxs;
            List<Box> res = result.OrderBy(u => u.id).ToList();
            if (res.Count() == 0)
                return new { Data = res, Count = res.Count(), IsError = true, Message = "صندوقی ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }

         public int AddBoxFromAdmin(Box box)
        {
            _context.Boxs.Add(box);
            _context.SaveChanges();
            return box.id;
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

        public PagedList<Box> GetBox(int pageId = 1, string filternumber = "")
        {
            IQueryable<Box> result = _context.Boxs.OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filternumber))
            {
                result = result.Where(x => x.number.Contains(filternumber));
            }
            PagedList<Box> res = new PagedList<Box>(result, pageId, 10);
            return res;
        }
    }
}
