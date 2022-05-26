using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice.Models
{
    public class Recipe
    {
      public int Id { get; set; }  
      public string Picture { get; set; }
      public string Title { get; set; }
      public string subtitle { get; set; }
      public string category { get; set; }
      public string CreatorId { get; set; }
    }

    public class FavoriteRecipeViewModel : Recipe
    {
      public int FavoriteId { get; set; }
    }
}