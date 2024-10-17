using SharedKernel;

namespace Domain.Notification;

public sealed record NotificationItemCompletedDomainEvent(Guid ItemId) : IDomainEvent;
