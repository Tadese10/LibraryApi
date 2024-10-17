using SharedKernel;

namespace Domain.Book;

public sealed record BookItemCompletedDomainEvent(Guid itemId) : IDomainEvent;
