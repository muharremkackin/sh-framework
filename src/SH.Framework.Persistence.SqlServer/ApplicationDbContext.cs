using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SH.Framework.Domain.Entities;
using SH.Framework.Persistence.Configurations;

namespace SH.Framework.Persistence.SqlServer;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
{
    public DbSet<LookUp> LookUps { get; set; }
    public DbSet<LookUpValue> LookUpValues { get; set; }
    public DbSet<Parameter> Parameters { get; set; }
    public DbSet<ServiceReference> ServiceReferences { get; set; }
    public DbSet<Localization> Localizations { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
    }
}