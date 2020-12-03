using Microsoft.EntityFrameworkCore;

namespace src.HelloWorld
{
    public class EFContext : DbContext
    {
        public virtual DbSet<Basket> Basket { get; set; }
        public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //use this to configure the contex
    }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //use this to configure the model
        modelBuilder.Entity<Basket>()
                    .HasKey(c => c.itemName);
    }

    }
}