using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public class DeceasedName
    {
        public int id { get; set; }

        [Display(Name = "نام و نام خانوادگی ")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string deceasedFullName { get; set; }

        [Display(Name = "نام مستعار ")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string deceaseAalias { get; set; }

         [Display(Name = "جنسیت ")]
        //0-mard
        //1-zan
        public bool deceasedSex { get; set; }

        public int charityId { get; set; }

    }
}
