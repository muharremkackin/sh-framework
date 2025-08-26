using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class LocalizationConfiguration: BaseConfiguration<Localization, Guid>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Localization> builder)
    {
        builder.ToTable(Localization.Table, Localization.Schema);
    }
}