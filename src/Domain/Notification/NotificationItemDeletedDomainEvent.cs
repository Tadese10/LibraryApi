using SharedKernel;

namespace Domain.Notification;

public sealed record TaskItemDeletedDomainEvent(Guid ItemId) : IDomainEvent;
