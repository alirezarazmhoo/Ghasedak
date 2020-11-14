using Ghasedak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.ViewModel
{
    public class BoxIncomeViewModel
    {
        public string number { get; set; }
        public string factorNumber { get; set; }
        public long price { get; set; }
        public EnumStatus status { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public string assignmentDate { get; set; }
        public int charityId { get; set; }
    }
}
