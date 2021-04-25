using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    
    public class FinancialAid
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "نام حامی")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string name { get; set; }      

        [Display(Name = "قیمت")]
        public long price { get; set; }
        [ForeignKey("Charity")]
        public int? charityId { get; set; }
        [JsonIgnore]

        public virtual Charity Charity { get; set; }
        public int? opratorId { get; set; }
        [ForeignKey("FinancialServiceType")]
        public int financialServiceTypeId { get; set; }
        [JsonIgnore]

        public virtual FinancialServiceType FinancialServiceType { get; set; }
        public PayType payType { get; set; }

    }
}
