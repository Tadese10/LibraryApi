using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Book;
using MongoDB.Driver;
using SharedKernel;

namespace Application.Books.Delete;

internal sealed class DeleteBookCommandHandler(IBookRepository repository)
    : ICommandHandler<DeleteBookCommand>
{
    public async Task<Result> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        Book book = await repository.FindOneAsync(t => t.Id ==  command.Id, cancellationToken);

        if (book == null)
        {
            return Result.Failure(BookItemErrors.NotFound(command.Id));
        }

        await repository.DeleteByIdAsync(book.Id, cancellationToken);

        book.Raise(new BookItemDeletedDomainEvent(book.Id));

        return Result.Success();
    }
}
