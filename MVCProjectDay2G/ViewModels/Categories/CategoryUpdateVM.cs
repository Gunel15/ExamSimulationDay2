using MVCProjectDay2G.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCProjectDay2G.ViewModels.Categories
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }
     
    }
}
