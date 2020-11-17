﻿using Ghasedak.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service.Interface
{
    public interface ISponsorPay
    {
       
        PagedList<SponsorPay> GetSponsorPay(int charityId,int pageId = 1);
       
        
    }
}
