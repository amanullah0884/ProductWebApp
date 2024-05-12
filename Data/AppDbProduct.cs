using Microsoft.EntityFrameworkCore;

namespace ProductWebApp.Data
{
    public class AppDbProduct : DbContext
    {
        public AppDbProduct(DbContextOptions<AppDbProduct>options) : base(options)
        { 

        }
        public DbSet<Model.Product> Products { get; set; }
        //public object Product { get; internal set; }
    }
}
