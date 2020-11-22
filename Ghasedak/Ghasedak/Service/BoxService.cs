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

        public object GetBox(int opratorId)
        {
            IQueryable<Box> result = _context.Boxs.Where(x=>x.opratorId==opratorId);
            List<Box> res = result.OrderBy(u => u.id).ToList();
            if (res.Count() == 0)
                return new { Data = res, Count = res.Count(), IsError = true, Message = "صندوقی ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }

         public int AddBoxFromAdmin(Box box)
        {
            box.guidBox = Guid.NewGuid();
            _context.Boxs.Add(box);
            _context.SaveChanges();
            return box.id;
        }

        

        public PagedList<Box> GetBox(int charityId,int pageId = 1, string filternumber = "")
        {
            IQueryable<Box> result = _context.Boxs.Where(x=>x.charityId==charityId).OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filternumber))
            {
                result = result.Where(x => x.number.Contains(filternumber));
            }
            PagedList<Box> res = new PagedList<Box>(result, pageId, 10);
            return res;
        }
    }
}
