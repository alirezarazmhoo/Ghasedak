using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public enum CeremonyType
    {
        Tarhim = 1,
        Hafte = 2,
        Chehelom = 3,
        Sal = 4,
        eid=5
    }
    public class FlowerCrown
    {
        [Key]
        public int id { get; set; }
        

              

        [Display(Name = "قیمت")]
        public long price { get; set; }
        public CeremonyType CeremonyType { get; set; }
        [ForeignKey("Charity")]
        public int? charityId { get; set; }
        public virtual Charity Charity { get; set; }

        
        public int? opratorId { get; set; }
        

        [ForeignKey("FlowerCrownType")]
        public int flowerCrownTypeId { get; set; }
        public virtual FlowerCrownType FlowerCrownType { get; set; }
        [ForeignKey("DeceasedName")]
        public int deceasedNameId { get; set; }
        public virtual DeceasedName DeceasedName { get; set; }

        public int donatorId { get; set; }

        public int IntroducedId { get; set; }

        [Display(Name = "تاریخ ثبت ")]
        [MaxLength(30, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string registerDate { get; set; }
    }
}
