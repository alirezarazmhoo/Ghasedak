using Ghasedak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.ViewModel
{
    public class FlowerCrownAdminViewModel
    {
        public FlowerCrown flowerCrown { get; set; }
        public Oprator oprator { get; set; }
        public Donator donator { get; set; }
        public Donator introduced { get; set; }
        public DeceasedName deceasedName { get; set; }
       

    }
}
