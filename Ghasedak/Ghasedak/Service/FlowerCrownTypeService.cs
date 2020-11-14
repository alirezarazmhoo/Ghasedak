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
    public class FlowerCrownTypeService : IFlowerCrownType
    {
        private Context _context;
        public FlowerCrownTypeService(Context context)
        {
            _context = context;
        }

        public object GetFlowerCrownType(int charityId)
        {
            IQueryable<FlowerCrownType> result = _context.FlowerCrownTypes.Where(x=>x.charityId==charityId);
            List<FlowerCrownType> res = result.OrderBy(u => u.id).ToList();
            if (res.Count() == 0)
                return new { Data = res, Count = res.Count(), IsError = true, Message = "نوع تاج گل ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }

         public int AddFlowerCrownTypeFromAdmin(FlowerCrownType FlowerCrownType)
        {
            _context.FlowerCrownTypes.Add(FlowerCrownType);
            _context.SaveChanges();
            return FlowerCrownType.id;
        }

        

        public PagedList<FlowerCrownType> GetFlowerCrownType(int charityId,int? pageId = 1,string filtertitle="")
        {
            IQueryable<FlowerCrownType> result = _context.FlowerCrownTypes.OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filtertitle))
            {
                result = result.Where(x => x.title.Contains(filtertitle));
            }
            PagedList<FlowerCrownType> res = new PagedList<FlowerCrownType>(result, Convert.ToInt32(pageId), 10);
            return res;
        }
    }
}
