using Microsoft.EntityFrameworkCore;
using ProductWebApi.Models;

namespace ProductWebApi.Data
{
    public class ProdutWebApiDbContex : DbContext
    {
        public ProdutWebApiDbContex(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
