using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface IFlowerCrown
    {
        object GetFlowerCrown(int charityId);
        PagedList<FlowerCrown> GetFlowerCrown(int pageId = 1, string filternumber = "");
        int AddFlowerCrownFromAdmin(FlowerCrown FlowerCrown);
        object AddFlowerCrown(FlowerCrown item, Oprator oprator);      
        
    }
}
