using EcomDomain.Enities;
using EcomInfrastucture.DataModels;
using Microsoft.EntityFrameworkCore;
namespace EcomInfrastucture.DataContext;

public class EcomDbContext : DbContext,IEcomDbContext
{
    public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options)
    {

    }
    public DbSet<ProductDataModel> Products { get; set; }
}

