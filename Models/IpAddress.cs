using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Wefate.Models
{
    public class IpAddress
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Display(Name ="地址")]
        public string Address { get; set; }
        [StringLength(10)]
        [Display(Name = "楼层")]
        public string floor { get; set; }

        [RegularExpression(@"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$")]
        public string Ip { get; set; }
    }
}
