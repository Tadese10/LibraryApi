using SharedKernel;

namespace Domain.Notification;

public sealed record ReservationItemCreatedDomainEvent(Guid ItemId) : IDomainEvent;
