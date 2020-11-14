using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface IFinancialServiceType
    {
        object GetFinancialServiceType(int charityId);
        PagedList<FinancialServiceType> GetFinancialServiceType(int charityId,int? pageId = 1,string filtertitle="");
        int AddFinancialServiceTypeFromAdmin(FinancialServiceType financialServiceType);


    }
}
