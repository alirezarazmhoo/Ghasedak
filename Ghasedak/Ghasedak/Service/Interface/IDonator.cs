using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface IDonator
    {
        object GetDonator(int charityId);
        PagedList<Donator> GetDonator(int charityId,int? pageId = 1,string filterfullName="");
        int AddDonatorFromAdmin(Donator Donator);
        object SearchDonator(string donatorFullName, string donatorAalias,string donatorMobile, int charityId);
        
        
    }
}
