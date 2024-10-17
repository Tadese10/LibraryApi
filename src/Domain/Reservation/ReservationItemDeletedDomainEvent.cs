using SharedKernel;

namespace Domain.Reservation;

public sealed record TaskItemDeletedDomainEvent(Guid ItemId) : IDomainEvent;
