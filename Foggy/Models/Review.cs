using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foggy.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public Game Game { get; set; }
        [Required]
        public bool Positive { get; set; }
        [Required]
        [StringLength(500)]
        public string Text { get; set; }
    }
}