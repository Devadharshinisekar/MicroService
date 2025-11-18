using EcomDomain.Enities;
using EcomInfrastucture.DataModels;
using Microsoft.EntityFrameworkCore;
namespace EcomInfrastucture.DataContext;

public class EcomDbContext : DbContext, IEcomDbContext
{
    public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options)
    {

    }
    public DbSet<ProductDataModel> Products { get; set; }
    public DbSet<OrderDataModel> Orders { get; set; }
    public DbSet<OrderItemDataModel> OrderItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDataModel>()
            .HasMany(o => o.Items)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}

