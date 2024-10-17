using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Book;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Books.Get;

internal sealed class GetBookQueryHandler(IBookRepository repository) : IQueryHandler<GetBookQuery, List<BookResponse>>
{
    public async Task<Result<List<BookResponse>>> Handle(GetBookQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Book> data = await repository.GetAllAsync(cancellationToken);
        var items = data.Select(book => new BookResponse
        {
            Id = book.Id,
           Author = book.Author,
           Title = book.Title,
           Status = book.Status,
           BorrowedBy = book.BorrowedBy,
           ReservedBy = book.ReservedBy,
           ReturnDate = book.ReturnDate,
        }).ToList();

        return Result.Success(items);
    }
}
