using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Entities;

namespace SH.Framework.Persistence.Configurations;

public class ServiceReferenceConfiguration: BaseConfiguration<ServiceReference, Guid>
{
    protected override void ConfigureEntity(EntityTypeBuilder<ServiceReference> builder)
    {
        builder.ToTable(ServiceReference.Table, ServiceReference.Schema);
    }
}