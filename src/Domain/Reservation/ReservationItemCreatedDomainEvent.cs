using SharedKernel;

namespace Domain.Reservation;

public sealed record ReservationItemCreatedDomainEvent(Guid ItemId) : IDomainEvent;
