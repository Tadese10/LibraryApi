using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Book;
using Domain.Notification;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Books.GetById;

internal sealed class GetTasksByIdQueryHandler(IBookRepository repository) : IQueryHandler<GetBookByIdQuery, BookResponse>
{
    public async Task<Result<BookResponse>> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
    {
        Book book = await repository.FindOneAsync(item => item.Id == query.Id, cancellationToken);
        if (book is null)
        {
            return Result.Failure<BookResponse>(ReservationItemErrors.NotFound(query.Id));
        }

        var data = new BookResponse
        {
            Id = book.Id,
            Author = book.Author,
            Title = book.Title,
            Status = book.Status,
            BorrowedBy = book.BorrowedBy,
            ReservedBy = book.ReservedBy,
            ReturnDate = book.ReturnDate,
        };


        return data;
    }
}
