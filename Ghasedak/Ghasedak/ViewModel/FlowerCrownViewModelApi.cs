using Ghasedak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.ViewModel
{
    public class FlowerCrownViewModelApi
    {
        public long price { get; set; }
        public CeremonyType CeremonyType { get; set; }
        public PayType payType { get; set; }
                        

        public int flowerCrownTypeId { get; set; }
        public string registerDate { get; set; }
        public Guid guidDeceasedName { get; set; }
        public Guid guidDonator { get; set; }
        public Guid guidIntroduced { get; set; }
        
    }
}
