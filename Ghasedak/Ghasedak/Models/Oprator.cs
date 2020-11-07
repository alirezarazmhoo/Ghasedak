using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public class Oprator
    {
        [Key]
        public int id { get; set; }
       

        [Display(Name = "نام کاربری")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string userName { get; set; }
        
        [Display(Name = "پسورد")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string password { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string fullName { get; set; }
         [Display(Name = "کد  ")]
        [MaxLength(30, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string code { get; set; }
        [Display(Name = "آدرس ")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string address { get; set; }
       
        [Display(Name = "توضیحات ")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string description { get; set; }
        [Display(Name = "موبایل ")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string mobile { get; set; }
        [Display(Name = "کد ملی ")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string nationalcode { get; set; }
        [Display(Name = "عکس")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string imageName { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }

        [Display(Name = "وضعیت")]
        public bool status { get; set; }
        [ForeignKey("Charity")]
        public int CharityId { get; set; }
        public virtual Charity Charity { get; set; }
    }
}
