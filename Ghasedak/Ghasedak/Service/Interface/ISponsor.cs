using Ghasedak.Models;
using Ghasedak.ViewModel;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface ISponsor
    {
        object GetSponsor(int charityId,int opratorId);
        PagedList<Sponsor> GetSponsor(int pageId = 1);
        int AddSponsorFromAdmin(Sponsor Sponsor);
        object AddSponsor(IEnumerable<SponsorViewModel> SponsorViewModel, Oprator oprator);

    }
}
