using MVCProjectDay2G.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCProjectDay2G.ViewModels.Categories
{
    public class CategoryCreateVM
    {
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }
      
    }
}
