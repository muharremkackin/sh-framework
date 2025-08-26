using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace SH.Framework.Application.Common.Authentication;

public static class RegisterAuthenticationConfiguration
{
    public static void AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationOptions = configuration.GetSection("Authentication").Get<AuthenticationOptions>()
            ?? throw new ArgumentNullException(nameof(AuthenticationOptions));
        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));
        
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = authenticationOptions.TokenValidationParameters();
                
                options.Events = new JwtBearerEvents()
                {
                    OnChallenge = async (context) =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        if (context.AuthenticateFailure is SecurityTokenExpiredException securityTokenExpiredException)
                        {
                            await context.Response.WriteAsJsonAsync(new
                                { message = securityTokenExpiredException.Message });
                            return;
                        }
                        
                        await context.Response.WriteAsJsonAsync(new
                            { message = "Invalid token" });
                    }
                };
            });

        services.AddAuthorization();
    }

    public static void UseAuthenticationConfiguration(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}