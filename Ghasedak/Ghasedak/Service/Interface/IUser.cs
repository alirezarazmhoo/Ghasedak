using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
   public interface IUser
    {
       PagedList<User> GetUsers(int pageId = 1, string filterFullName = "");
    }
}
