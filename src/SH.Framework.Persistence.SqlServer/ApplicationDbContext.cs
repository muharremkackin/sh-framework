using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SH.Framework.Domain.Entities;
using SH.Framework.Persistence.Configurations;

namespace SH.Framework.Persistence.SqlServer;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): IdentityDbContext<User, Role, Guid>
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
    }
}