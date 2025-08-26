using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.SqlServer.Seeds;

public class AuthenticationSeed(IServiceProvider provider)
{
    public async Task SeedAsync()
    {
        var context = provider.GetRequiredService<ApplicationDbContext>();
        if (!await context.Roles.AnyAsync())
            await SeedRoleAsync(context);
        
        var userManager = provider.GetRequiredService<UserManager<User>>();
        
        if (!await userManager.Users.AnyAsync())
            await SeedUserAsync(userManager);
    }

    private async Task SeedRoleAsync(ApplicationDbContext context)
    {
        var roles = new List<Role>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Api",
                NormalizedName = "API",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Reporter",
                NormalizedName = "REPORTER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        };
        
        await context.Roles.AddRangeAsync(roles);
        await context.SaveChangesAsync();
    }

    private async Task SeedUserAsync(UserManager<User> userManager)
    {
        var admin = new User()
        {
            UserName = "muharrem.kackin",
            NormalizedUserName = "MUHARREM.KACKIN",
            Email = "muharrem.kackin@mokaunited.com",
            NormalizedEmail = "MUHARREM.KACKIN@MOKAUNITED.COM",
            EmailConfirmed = true,
            PhoneNumber = "+905304787627",
            PhoneNumberConfirmed = true,
        };


        await userManager.CreateAsync(admin, "Z;_vf{v*,g+NFi)(6g");
        await userManager.AddToRoleAsync(admin, "Admin");
    }
    
    public async Task UnSeedAsync()
    {
        var context = provider.GetRequiredService<ApplicationDbContext>();

        await context.Database.ExecuteSqlRawAsync($"DELETE FROM [{UserRole.Schema}].[{UserRole.Table}]");
        await context.Database.ExecuteSqlRawAsync($"DELETE FROM [{UserClaim.Schema}].[{UserClaim.Table}]");
        await context.Database.ExecuteSqlRawAsync($"DELETE FROM [{UserToken.Schema}].[{UserToken.Table}]");
        await context.Database.ExecuteSqlRawAsync($"DELETE FROM [{UserLogin.Schema}].[{UserLogin.Table}]");
        await context.Database.ExecuteSqlRawAsync($"DELETE FROM [{RoleClaim.Schema}].[{RoleClaim.Table}]");
        await context.Database.ExecuteSqlRawAsync($"DELETE FROM [{Role.Schema}].[{Role.Table}]");
        await context.Database.ExecuteSqlRawAsync($"DELETE FROM [{User.Schema}].[{User.Table}]");
    }
}