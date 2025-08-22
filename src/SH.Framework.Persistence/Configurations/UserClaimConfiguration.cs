using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class UserClaimConfiguration: BaseConfiguration<UserClaim>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable(UserClaim.Table, UserClaim.Schema);
    }
}