using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
   public interface ICharity
    {
        Task<object> GetCharityAsync(int chrityId);
        Task<bool> ActiveCharityAsync(int chrityId, string code);

       PagedList<Charity> GetCharity(int pageId = 1, string filterFullName = "");
    }
}
