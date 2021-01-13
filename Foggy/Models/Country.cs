using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foggy.Models
{
    public class Country
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Alpha2 { get; set; }
        [StringLength(3, MinimumLength = 3)]
        public string Alpha3 { get; set; }
        public int UnCode { get; set; }
        [Required]
        public virtual ICollection<Discount> Discounts { get; set; }
    }
}