using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public class AllTableData
    {
        public int id { get; set; }
       

        [Display(Name = "نام جدول ")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string nameTable { get; set; }

        [Display(Name = "json ")]
      
        public string json { get; set; }

        [Display(Name = "تاریخ ثبت ")]
        public string registerDate { get; set; }
        [Display(Name = "صدا زده شده ")]

        public bool isCall { get; set; }
         [Display(Name = "op ")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string op { get; set; }
       
    }
}
