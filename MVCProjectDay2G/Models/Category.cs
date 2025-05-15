using System.ComponentModel.DataAnnotations;

namespace MVCProjectDay2G.Models
{
    public class Category:BaseEntity
    {
        [MinLength(5), MaxLength(20)]
        public string Name {  get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
