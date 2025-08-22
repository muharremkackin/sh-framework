using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class UserConfiguration: BaseConfiguration<User>
{
    protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(User.Table, User.Schema);
    }
}