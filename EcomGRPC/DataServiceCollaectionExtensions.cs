using EcomApplication.Product.CommandHandelers;
using EcomApplication.Product.QueryHandlers;
using EcomDomain.IRepository;
using EcomInfrastucture.DataContext;
using EcomInfrastucture.Repository.ReadRepository;
using EcomInfrastucture.Repository.WriteRepository;
using Microsoft.EntityFrameworkCore;
// using EcomGRPC.Services;

namespace EcomGRPC;

public static class DataServiceCollaectionExtensions
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EcomDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            build => build.MigrationsAssembly("EcomInfrastucture"));
        });
        services.AddScoped<IEcomDbContext>(provider => provider.GetRequiredService<EcomDbContext>() ?? throw new InvalidOperationException());
        services.AddScoped<IProductAggregateRepository, ProductAggregateRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCommandHandler, ProductCommandHandler>();
        services.AddScoped<IProductQueryHandler, ProductQueryHandler>();
    }
    
}
