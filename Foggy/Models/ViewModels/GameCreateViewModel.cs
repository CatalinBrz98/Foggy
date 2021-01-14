using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foggy.Models.ViewModels
{
    public class GameCreateViewModel
    {
        public Game Game { get; set; }
        public IEnumerable<GameCategory> GameCategories { get; set; }
        public IEnumerable<int> SelectedGameCategoryIds { get; set; }
    }
}