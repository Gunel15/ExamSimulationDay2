using MVCProjectDay2G.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCProjectDay2G.ViewModels.Products
{
    public class ProductListVM
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(30)]
        public string Title { get; set; }
        [MinLength(5), MaxLength(50)]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Count { get; set; }
        public float Rating { get; set; }
        public string CategoryName {  get; set; }
    }
}
