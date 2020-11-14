using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface IDeceasedName
    {
        object GetDeceasedName(int charityId);
        PagedList<DeceasedName> GetDeceasedName(int charityId,int? pageId = 1,string filterfullName="");
        int AddDeceasedNameFromAdmin(DeceasedName DeceasedName);
        
        
    }
}
