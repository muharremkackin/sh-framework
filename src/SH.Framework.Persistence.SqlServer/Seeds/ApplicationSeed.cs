using Microsoft.Extensions.DependencyInjection;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.SqlServer.Seeds;

public class ApplicationSeed(IServiceProvider provider)
{
    public async Task SeedAsync()
    {
        var context = provider.GetRequiredService<ApplicationDbContext>();

        var parameters = new List<Parameter>()
        {
            new()
            {
                Title = "Maintenance Mode",
                Code = "MaintenanceMode",
                Value = "false",
                Deletable = false,
            },
            new()
            {
                Title = "Default Language",
                Code = "DefaultLanguage",
                Value = "en-US",
                Deletable = false,
            },
            new()
            {
                Title = "Theme Mode",
                Code = "ThemeMode",
                Value = "light",
                Deletable = false,
            },
        };
    }
}