using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class UserRoleConfiguration: BaseConfiguration<UserRole>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(UserRole.Table, UserRole.Schema);
    }
}