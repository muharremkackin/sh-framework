using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SH.Framework.Domain.Common;
using SH.Framework.Domain.Common.Columns;

namespace SH.Framework.Persistence.Configurations;

public abstract class BaseConfiguration<TEntity, TKey>: IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity where TKey : struct
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureKey(builder);
        
        ConfigureEntity(builder);
        
        ConfigureTitleColumn(builder);
        ConfigureDescriptionColumn(builder);
        ConfigureCodeColumn(builder);
        ConfigureValueColumn(builder);
        ConfigureHostColumn(builder);
        ConfigurePortColumn(builder);
        ConfigureUserNameColumn(builder);
        ConfigurePasswordColumn(builder);
        ConfigureApiKeyColumn(builder);
        ConfigureApiSecretColumn(builder);
        ConfigureAdditionalInfoColumn(builder);
        ConfigureDeletableColumn(builder);
        ConfigureTypeIdColumn(builder);
        ConfigureGroupIdColumn(builder);
        ConfigureCategoryIdColumn(builder);
        ConfigureStatusIdColumn(builder);
        ConfigureAuditColumns(builder);
    }
    
    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);

    protected virtual void ConfigureKey(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasPrimaryKey<TKey>).IsAssignableFrom(typeof(TEntity)))
        {
            builder.HasKey(x => ((IHasPrimaryKey<TKey>)x).Id);
            builder.Property(x => ((IHasPrimaryKey<TKey>)x).Id).ValueGeneratedOnAdd();
        }
    }

    protected virtual void ConfigureTitleColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasTitleColumn).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property(x => ((IHasTitleColumn)x).Title).HasMaxLength(255);
        }
    }
    
    protected virtual void ConfigureDescriptionColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasDescriptionColumn).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property(x => ((IHasDescriptionColumn)x).Description).HasMaxLength(4000);
        }
    }
    
    protected virtual void ConfigureCodeColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasCodeColumn).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property(x => ((IHasCodeColumn)x).Code).HasMaxLength(255);
        }
    }
    
    protected virtual void ConfigureValueColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasValueColumn).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property(x => ((IHasValueColumn)x).Value).HasMaxLength(10000);
        }
    }
    
    protected virtual void ConfigureHostColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasHostColumn).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property(x => ((IHasHostColumn)x).Host).HasMaxLength(1000);
        }
    }
    
    protected virtual void ConfigurePortColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasPortColumn).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property(x => ((IHasPortColumn)x).Port);
        }
    }
    
    protected virtual void ConfigureUserNameColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasUserNameColumn).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property(x => ((IHasUserNameColumn)x).UserName).HasMaxLength(1000);
        }
    }

    protected virtual void ConfigurePasswordColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasPasswordColumn).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property(x => ((IHasPasswordColumn)x).Password).HasMaxLength(1000);
        }
    }

    protected virtual void ConfigureApiKeyColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasKeyColumn).IsAssignableFrom(typeof(TEntity)))
            builder.Property(x => ((IHasKeyColumn)x).Key).HasMaxLength(4000);
    }

    protected virtual void ConfigureApiSecretColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasSecretColumn).IsAssignableFrom(typeof(TEntity)))
            builder.Property(x => ((IHasSecretColumn)x).Secret).HasMaxLength(4000);   
    }

    protected virtual void ConfigureAdditionalInfoColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasAdditionalInfoColumn).IsAssignableFrom(typeof(TEntity)))
            builder.Property(x => ((IHasAdditionalInfoColumn)x).AdditionalInfo).HasMaxLength(4000);  
    }

    protected virtual void ConfigureDeletableColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasDeletableColumn).IsAssignableFrom(typeof(TEntity)))
            builder.Property(x => ((IHasDeletableColumn)x).Deletable); 
    }

    protected virtual void ConfigureTypeIdColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasTypeIdColumn).IsAssignableFrom(typeof(TEntity)))
            builder.Property(x => ((IHasTypeIdColumn)x).TypeId);   
    }
    
    protected virtual void ConfigureGroupIdColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasGroupIdColumn).IsAssignableFrom(typeof(TEntity)))
            builder.Property(x => ((IHasGroupIdColumn)x).GroupId);   
    }

    protected virtual void ConfigureCategoryIdColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasCategoryColumn).IsAssignableFrom(typeof(TEntity)))
            builder.Property(x => ((IHasCategoryColumn)x).CategoryId);  
    }
    
    protected virtual void ConfigureStatusIdColumn(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasStatusIdColumn).IsAssignableFrom(typeof(TEntity)))
            builder.Property(x => ((IHasStatusIdColumn)x).StatusId);   
    }

    protected virtual void ConfigureAuditColumns(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(IHasAuditColumns<TKey?>).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property(x => ((IHasAuditColumns<TKey?>)x).CreatedDate);
            builder.Property(x => ((IHasAuditColumns<TKey?>)x).CreatedById);
            builder.Property(x => ((IHasAuditColumns<TKey?>)x).ModifiedDate);
            builder.Property(x => ((IHasAuditColumns<TKey?>)x).ModifiedById);
            builder.Property(x => ((IHasAuditColumns<TKey?>)x).DeletedDate);
            builder.Property(x => ((IHasAuditColumns<TKey?>)x).DeletedById);
            
        }
    }
}