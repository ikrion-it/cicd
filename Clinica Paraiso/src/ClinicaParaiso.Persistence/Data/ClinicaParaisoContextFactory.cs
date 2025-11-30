using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClinicaParaiso.Persistence.Data
{
    public class ClinicaParaisoContextFactory : IDesignTimeDbContextFactory<ClinicaParaisoContext>
    {
        public ClinicaParaisoContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ClinicaParaisoConnectionProduction")
                ?? throw new InvalidOperationException("Conexão com o banco não encotrada");

            var optionsBuilder = new DbContextOptionsBuilder<ClinicaParaisoContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ClinicaParaisoContext(optionsBuilder.Options);
        }
    }
}
