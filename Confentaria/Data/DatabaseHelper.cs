using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Confentaria.Data
{
    public static class DatabaseHelper
    {
        public static DbContextOptions<ConfentariaDbContext> GetDbContextOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfentariaDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return optionsBuilder.Options;
        }

        public static string GetConnectionString()
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                return configuration.GetConnectionString("DefaultConnection") 
                    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }
            catch
            {
                // Fallback para connection string padrão se não conseguir ler o arquivo
                return "Server=localhost,1433;Database=ConfentariaDB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";
            }
        }

        public static ConfentariaDbContext CreateDbContext()
        {
            var connectionString = GetConnectionString();
            var options = GetDbContextOptions(connectionString);
            return new ConfentariaDbContext(options);
        }
    }
}

