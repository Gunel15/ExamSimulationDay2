using Microsoft.EntityFrameworkCore;
using MVCProjectDay2G.Models;

namespace MVCProjectDay2G.DataAccessLayer
{
    public class Project2DbContext:DbContext
    {
        public Project2DbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<Product>Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
