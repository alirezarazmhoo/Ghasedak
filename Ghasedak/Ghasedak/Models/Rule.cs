﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public class Rule
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "توضیحات ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string description { get; set; }
    }
}
