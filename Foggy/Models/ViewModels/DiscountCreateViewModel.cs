using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foggy.Models.ViewModels
{
    public class DiscountCreateViewModel
    {
        public Discount Discount { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<int> SelectedCountryIds { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public int SelectedGameId { get; set; }
    }
}