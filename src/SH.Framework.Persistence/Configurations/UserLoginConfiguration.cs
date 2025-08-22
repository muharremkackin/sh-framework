using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class UserLoginConfiguration: BaseConfiguration<UserLogin>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable(UserLogin.Table, UserLogin.Schema);
    }
}