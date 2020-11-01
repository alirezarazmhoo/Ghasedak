using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Utility
{
    public class LoginUserAdmin
    {
        [Display(Name = "نام کاربری")]
       
        public string userName { get; set; }
        [Display(Name = "پسورد")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string password { get; set; }
        [Required(ErrorMessage = "لطفا جواب جمع را وارد نمایید")]
        [Display(Name = "جواب جمع")]
        public string Captcha { get; set; }
         [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
        public int? majorId { get; set; }

    }
}
