using SharedKernel;

namespace Domain.Book;

public sealed record BookItemCreatedDomainEvent(Guid ItemId) : IDomainEvent;
