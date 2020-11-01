﻿using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface IBoxIncome
    {
       
        PagedList<BoxIncome> GetBoxIncome(int pageId = 1);
       
        
    }
}
