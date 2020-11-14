using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface IFinancialAid
    {
        object GetFinancialAid(int opratorId,int charityId);
        PagedList<FinancialAid> GetFinancialAid(int pageId = 1, string filternumber = "");
        int AddFinancialAidFromAdmin(FinancialAid FinancialAid);
        
        
    }
}
