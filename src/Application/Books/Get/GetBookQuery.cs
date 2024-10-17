using Application.Abstractions.Messaging;

namespace Application.Books.Get;

public sealed record GetBookQuery(): IQuery<List<BookResponse>>;
