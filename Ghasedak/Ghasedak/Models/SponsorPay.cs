using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public class SponsorPay
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string description { get; set; }

        [Display(Name = "قیمت")]
        public long? price { get; set; }

        [Display(Name = "کد پذیرنده")]
        [MaxLength(30, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string recieverCode { get; set; }

        [Display(Name = "شماره دستگاه")]
        [MaxLength(30, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string deviceCode { get; set; }

        [Display(Name = "شماره پایانه")]
        [MaxLength(30, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string terminalCode { get; set; }

        
        public int charityId { get; set; }
        public int opratorId { get; set; }
        [ForeignKey("Sponsor")]
        public int sponsorId { get; set; }
        public virtual Sponsor Sponsor { get; set; }
        public PayType payType { get; set; }

    }
}
