using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class LookUpConfiguration: BaseConfiguration<LookUp, Guid>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LookUp> builder)
    {
        builder.ToTable(LookUp.Table, LookUp.Schema);
    }
}