using SH.Framework.Library.Cqrs;

namespace SH.Framework.Domain.Common;

public interface IEntity
{
   
}

public interface IHasDomainEvents
{
    public IReadOnlyCollection<INotification> Notifications { get; }
    public void AddNotification(INotification notification);
    public void ClearNotifications();
}