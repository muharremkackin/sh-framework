using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SH.Framework.Application.Common.Authentication;
using SH.Framework.Application.Features;
using SH.Framework.Library.Cqrs;

namespace SH.Framework.Application;

public static class RegisterApplication
{
    public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddCqrsLibraryConfiguration(Assembly.GetExecutingAssembly());  
        services.AddAuthenticationConfiguration(configuration);
    }

    public static void UseApplicationLayer(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthenticationConfiguration();
        app.MapFeatureEndpoints();
    }
}