using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface IFlowerCrownType
    {
        object GetFlowerCrownType(int charityId);
        PagedList<FlowerCrownType> GetFlowerCrownType(int charityId,int? pageId = 1,string filtertitle="");
        int AddFlowerCrownTypeFromAdmin(FlowerCrownType flowerCrownType);
        
        
    }
}
