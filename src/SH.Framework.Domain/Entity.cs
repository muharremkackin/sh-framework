using SH.Framework.Domain.Common;
using SH.Framework.Domain.Common.Columns;
using SH.Framework.Library.Cqrs;

namespace SH.Framework.Domain;

public abstract class Entity: IEntity, IHasDomainEvents, IHasPrimaryKey<Guid>
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

    public Guid Id { get; set; }
}