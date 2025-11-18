using EcomDomain.Enities;
using EcomInfrastucture.DataModels;
using Microsoft.EntityFrameworkCore;
namespace EcomInfrastucture.DataContext;

public interface IEcomDbContext
{
     public DbSet<ProductDataModel> Products { get; set; }
     public DbSet<OrderDataModel> Orders { get; set; }
     public DbSet<OrderItemDataModel> OrderItems { get; set; }

}
