using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class ParameterConfiguration: BaseConfiguration<Parameter, Guid>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Parameter> builder)
    {
        builder.ToTable(Parameter.Table, Parameter.Schema);
    }
}