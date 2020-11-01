using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "تاریخ در ماه ")]
       
        public int? day { get; set; }

        [Display(Name = "آدرس ")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string address { get; set; }
        

    }
}
