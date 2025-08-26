using Microsoft.AspNetCore.Identity;
using SH.Framework.Domain.Common;
using SH.Framework.Domain.Common.Columns;
using SH.Framework.Library.Cqrs;

namespace SH.Framework.Domain.Entities;

public class Role: IdentityRole<Guid>, IEntity, IHasDomainEvents, IHasPrimaryKey<Guid>
{
    public const string Schema = "Identity";
    public const string Table = nameof(Role);
    
    private readonly List<INotification> _notifications = new();
    public IReadOnlyCollection<INotification> Notifications  => _notifications.AsReadOnly();
    
    public void AddNotification(INotification notification)
    {
        _notifications.Add(notification);
    }

    public void ClearNotifications()
    {
        _notifications.Clear();
    }
}