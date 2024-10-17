using SharedKernel;

namespace Domain.Reservation;

public sealed record ReservationItemCompletedDomainEvent(Guid ItemId) : IDomainEvent;
