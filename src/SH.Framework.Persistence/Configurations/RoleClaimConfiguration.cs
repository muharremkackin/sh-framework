using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class RoleClaimConfiguration: BaseConfiguration<RoleClaim>
{
    protected override void ConfigureEntity(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable(RoleClaim.Table, RoleClaim.Schema);
    }
}