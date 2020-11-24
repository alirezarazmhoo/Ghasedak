using Ghasedak.Models;
using Ghasedak.ViewModel;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface IFinancialAid
    {
        FinancialAidAdminViewModel GetDataForAdmin(int financialAidId);

        object GetFinancialAid(int opratorId,int charityId);
        PagedList<FinancialAid> GetFinancialAidFromAdmin(int charityId,int pageId = 1, string filtername = "");
        int AddFinancialAidFromAdmin(FinancialAid FinancialAid);
        
        
    }
}
