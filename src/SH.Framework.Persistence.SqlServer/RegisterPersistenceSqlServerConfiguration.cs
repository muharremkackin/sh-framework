using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SH.Framework.Domain.Entities;
using SH.Framework.Persistence.SqlServer.Seeds;

namespace SH.Framework.Persistence.SqlServer;

public static class RegisterPersistenceSqlServerConfiguration
{
    public static void AddPersistenceSqlServerConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlServerOptions =>
            {
                sqlServerOptions.EnableRetryOnFailure();
            });

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production") return;
            
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        });

        services.AddIdentity<User, Role>(options =>
        {
            
        }).AddEntityFrameworkStores<ApplicationDbContext>();
    }

    public static void UsePersistenceSqlServerConfiguration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var provider = scope.ServiceProvider;
        
        new AuthenticationSeed(provider).SeedAsync().Wait();
    }
}