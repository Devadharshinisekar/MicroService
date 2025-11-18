using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EcomInfrastucture.DataContext;

public class EcomDbContextFactory :  IDesignTimeDbContextFactory<EcomDbContext>
{
    public EcomDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EcomDbContext>();

            // ⚙️ Replace this with your actual connection string
            optionsBuilder.UseSqlServer("Server=ASPLAP1859\\SQLEXPRESS;Database=Ecom;Trusted_Connection=True; TrustServerCertificate=True;");

            return new EcomDbContext(optionsBuilder.Options);
        }
}
