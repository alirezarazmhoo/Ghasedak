using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public class DischargeRoute
    {
        public int id { get; set; }
        [Display(Name = "کد ")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string code { get; set; }
       

        [Display(Name = "آدرس ")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string address { get; set; }
         [ForeignKey("Charity")]
        public int charityId { get; set; }
        public virtual Charity Charity { get; set; }
        
        public int? opratorId { get; set; }
        public Guid guidDischargeRoute { get; set; }

    }
}
