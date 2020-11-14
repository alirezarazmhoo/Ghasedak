using Ghasedak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.ViewModel
{
    public class FlowerCrownViewModel
    {
        public string fullName { get; set; }
        public int flowerCrownTypeId { get; set; }
        public int? donatorId { get; set; }
        public int? deceasedNameId { get; set; }
        public long price { get; set; }
        public CeremonyType CeremonyType { get; set; }
        public int? charityId { get; set; }
        public int? opratorId { get; set; }
        public string registerDate { get; set; }
        public string deceasedFullName { get; set; }
        public string deceaseAalias { get; set; }
        public string donatorAlias { get; set; }
        public string donatorMobile { get; set; }
        public string donatorFullName { get; set; }
        public bool isSendMessage { get; set; }
        public bool deceasedSex { get; set; }

    }
}
