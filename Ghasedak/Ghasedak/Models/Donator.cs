using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public class Donator
    {
        public int id { get; set; }

        [Display(Name = "نام و نام خانوادگی ")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string donatorFullName { get; set; }

        [Display(Name = "نام مستعار ")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string donatorAlias { get; set; }

        public int charityId { get; set; }
       

        [Display(Name = "موبایل ")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string donatorMobile { get; set; }

        [Display(Name = "تیک ارسال پیامک ")]
        public bool isSendMessage { get; set; }
        public Guid guidDonator { get; set; }

    }
}
