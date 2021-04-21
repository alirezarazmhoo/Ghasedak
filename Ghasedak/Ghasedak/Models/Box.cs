using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public class Box
    {
        public int id { get; set; }
        [Display(Name = "شماره ")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string number { get; set; }

        [Display(Name = "نام و نام خانوادگی ")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string fullName { get; set; }

        [Display(Name = "موبایل ")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string mobile { get; set; }

        [Display(Name = "تاریخ واگذاری ")]
        [MaxLength(30, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string assignmentDate { get; set; }

        [ForeignKey("dischargeRoute")]
        public int dischargeRouteId { get; set; }
        [JsonIgnore]

        public virtual DischargeRoute dischargeRoute { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
         [Display(Name = "آدرس ")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string address { get; set; }
        
        public int charityId { get; set; }
        public int? opratorId { get; set; }

        public Guid guidBox { get; set; }
        [Display(Name = "نوع صندوق")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string boxKind { get; set; }
         [Display(Name = "تاریخ در ماه ")]
       
        public int? day { get; set; }
       
    }
}
