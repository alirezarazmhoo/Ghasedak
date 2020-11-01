using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public class Setting
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "لوگو")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string logoName { get; set; }
        [NotMapped]
        public IFormFile logo { get; set; }

        [Display(Name = "نام شرکت")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string sherkatName { get; set; }

    }
}
