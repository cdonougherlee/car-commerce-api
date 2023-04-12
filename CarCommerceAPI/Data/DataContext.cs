using CarCommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarCommerceAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Van> Vans { get; set; }
        public DbSet<Electric> Electrics { get; set; }
        public DbSet<Ute> Utes { get; set; }
    }
}
