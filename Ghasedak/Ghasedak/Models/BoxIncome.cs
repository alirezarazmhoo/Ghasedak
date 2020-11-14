using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
    public enum EnumStatus
    {
        LackOfInventory = 2,
        Absence = 1,
        Other = 3,
    }
    public class BoxIncome
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "قیمت")]
        public long? price { get; set; }

        public EnumStatus status { get; set; }
        [ForeignKey("oprator")]
        public int opratorId { get; set; }
        public virtual Oprator oprator { get; set; }

        public double lon { get; set; }
        public double lat { get; set; }

        [ForeignKey("box")]
        public int boxId { get; set; }
        public virtual Box box { get; set; }

        [Display(Name = "تاریخ ثبت ")]
        [MaxLength(30, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string registerDate { get; set; }
        
        public int charityId { get; set; }
        

    }
}
