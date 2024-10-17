using SharedKernel;

namespace Domain.Book;

public sealed record BookItemDeletedDomainEvent(Guid ItemId) : IDomainEvent;
