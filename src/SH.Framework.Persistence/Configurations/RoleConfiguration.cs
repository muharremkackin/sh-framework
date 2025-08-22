using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class RoleConfiguration: BaseConfiguration<Role>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(Role.Table, Role.Schema);
    }
}