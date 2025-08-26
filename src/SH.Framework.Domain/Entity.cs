using SH.Framework.Domain.Common;
using SH.Framework.Domain.Common.Columns;
using SH.Framework.Library.Cqrs;

namespace SH.Framework.Domain;

public abstract class Entity: IEntity, IHasDomainEvents, IHasPrimaryKey<Guid>, IHasAuditColumns<Guid?>, IHasStatusIdColumn
{
    private readonly List<INotification> _notifications = new();
    
    public virtual IReadOnlyCollection<INotification> Notifications => _notifications.AsReadOnly();
    
    public virtual void AddNotification(INotification notification)
    {
        _notifications.Add(notification);
    }

    public virtual void ClearNotifications()
    {
        _notifications.Clear();
    }

    public virtual Guid Id { get; set; } 
    public virtual DateTime? CreatedDate { get; set; } 
    public virtual Guid? CreatedById { get; set; } 
    public virtual DateTime? ModifiedDate { get; set; } 
    public virtual Guid? ModifiedById { get; set; } 
    public virtual DateTime? DeletedDate { get; set; } 
    public virtual Guid? DeletedById { get; set; }
    public virtual int? StatusId { get; set; } = 1; // StatusEnum.Active
}