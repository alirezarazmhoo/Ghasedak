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
    public class SponsorPayService : ISponsorPay
    {
        private Context _context;
        public SponsorPayService(Context context)
        {
            _context = context;
        }
        public PagedList<SponsorPay> GetSponsorPay(int charityId,int pageId = 1)
        {
            IQueryable<SponsorPay> result = _context.SponsorPays.Where(x=>x.charityId==charityId).Include(x=>x.Sponsor).OrderByDescending(x => x.id);
            PagedList<SponsorPay> res = new PagedList<SponsorPay>(result, pageId, 10);
            return res;
        }
    }
}
