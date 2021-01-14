using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foggy.Models
{
    public class Discount
    {
        public int Id { get; set; }
        [Required]
        public float Percentage { get; set; }
        [Required]
        public Game Game { get; set; }
        public ICollection<Country> Countries { get; set; }
    }
}