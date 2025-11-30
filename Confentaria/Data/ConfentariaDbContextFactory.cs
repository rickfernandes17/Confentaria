using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Confentaria.Data
{
    public class ConfentariaDbContextFactory : IDesignTimeDbContextFactory<ConfentariaDbContext>
    {
        public ConfentariaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfentariaDbContext>();
            
            // Connection string para design-time (migrations)
            var connectionString = "Server=localhost,1433;Database=ConfentariaDB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";
            
            optionsBuilder.UseSqlServer(connectionString);

            return new ConfentariaDbContext(optionsBuilder.Options);
        }
    }
}

