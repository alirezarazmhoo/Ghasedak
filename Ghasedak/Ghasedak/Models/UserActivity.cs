using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Models
{
     public enum UserActivityEnum
    {
        register=1,
        edit=2,
        delete=3
    }
    public class UserActivity
    {
        public int id { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime date { get; set; }
        [ForeignKey("oprator")]
        public int? opratorId { get; set; }
        public virtual Oprator oprator { get; set; }
        public int charityId { get; set; }
         [Display(Name = "توضیحات")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string description { get; set; }
        public UserActivityEnum status { get; set; }
    }
}
