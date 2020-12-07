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
    public class DeceasedNameService : IDeceasedName
    {
        private Context _context;
        public DeceasedNameService(Context context)
        {
            _context = context;
        }

        public object GetDeceasedName(int charityId)
        {
            IQueryable<DeceasedName> result = _context.DeceasedNames.Where(x=>x.charityId==charityId);
            List<DeceasedName> res = result.OrderBy(u => u.id).ToList();
            if (res.Count() == 0)
                return new { Data = res, Count = res.Count(), IsError = true, Message = "متوفی ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }

         public int AddDeceasedNameFromAdmin(DeceasedName DeceasedName)
        {
            _context.DeceasedNames.Add(DeceasedName);
            _context.SaveChanges();
            return DeceasedName.id;
        }

        

        public PagedList<DeceasedName> GetDeceasedName(int charityId,int? pageId = 1,string filterfullName="")
        {
            IQueryable<DeceasedName> result = _context.DeceasedNames.Where(x=>x.charityId==charityId).OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filterfullName))
            {
                result = result.Where(x => x.deceasedFullName.Contains(filterfullName));
            }
            PagedList<DeceasedName> res = new PagedList<DeceasedName>(result, Convert.ToInt32(pageId), 10);
            return res;
        }
    }
}
