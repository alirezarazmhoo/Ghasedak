using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface IDischargeRoute
    {
        object GetDischargeRoute();
        PagedList<DischargeRoute> GetDischargeRoute(int pageId = 1, string filtercode = "");
        //object GetProvinces(int cityId);
        
    }
}
