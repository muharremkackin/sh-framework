using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class UserTokenConfiguration: BaseConfiguration<UserToken>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable(UserToken.Table, UserToken.Schema);
    }
}