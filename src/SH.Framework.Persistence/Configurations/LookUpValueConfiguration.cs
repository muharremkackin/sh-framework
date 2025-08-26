using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class LookUpValueConfiguration: BaseConfiguration<LookUpValue, Guid>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LookUpValue> builder)
    {
        builder.ToTable(LookUpValue.Table, LookUpValue.Schema);
    }
}