using MVCProjectDay2G.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCProjectDay2G.ViewModels.Categories
{
    public class CategoryGetVM
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
