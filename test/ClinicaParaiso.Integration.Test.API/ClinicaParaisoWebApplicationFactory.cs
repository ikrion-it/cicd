using ClinicaParaiso.Persistence.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.MsSql;

namespace ClinicaParaiso.Integration.Test.API
{
    public class ClinicaParaisoWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer sqlContainer =
            new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPassword("Strong@123")
                .WithEnvironment("ACCEPT_EULA", "Y")
                .WithEnvironment("MSSQL_PID", "Express")
                .WithEnvironment("MSSQL_AGENT_ENABLED", "true")
                .Build();

        private IServiceScope scope;
        ClinicaParaisoContext context { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                sqlContainer.StartAsync().GetAwaiter().GetResult();

                var baseCs = sqlContainer.GetConnectionString();

                var cs = new SqlConnectionStringBuilder(baseCs)
                {
                    TrustServerCertificate = true,
                    Encrypt = false
                }.ConnectionString;

                services.RemoveAll(typeof(DbContextOptions<ClinicaParaisoContext>));

                services.AddDbContext<ClinicaParaisoContext>(options =>
                {
                    options
                    .UseSqlServer(cs);
                });
            });

            base.ConfigureWebHost(builder);
        }

        public async Task InitializeAsync()
        {
            scope = Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<ClinicaParaisoContext>();
            context.Database.Migrate();
        }

        public async Task DisposeAsync()
        {
            scope?.Dispose();
            await sqlContainer.DisposeAsync();
        }
    }
}
