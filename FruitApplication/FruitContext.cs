using FruitApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcess
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>();


        }
        public DbSet<Fruit> Fruits { get; set; }
    }
}