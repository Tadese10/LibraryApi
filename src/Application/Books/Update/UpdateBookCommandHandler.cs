using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Book;
using Domain.Common;
using Domain.Notification;
using Domain.Users;
using Microsoft.AspNetCore.Http;
using SharedKernel;

namespace Application.Books.Update;

internal sealed class UpdateBookCommandHandler(IBookRepository repository)
    : ICommandHandler<UpdateBookCommand, Guid>
{
    public async Task<Result<Guid>> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        Book? book = await repository.FindOneAsync(u => u.Id == command.Id, cancellationToken);

        if (book == null)
        {
            return Result.Failure<Guid>(BookItemErrors.NotFound(command.Id));
        }

        book.Title = command.Title;
        book.Status = command.Status;
        book.Author = command.Author;

        book.Raise(new BookItemCreatedDomainEvent(book.Id));

        await repository.UpdateAsync(book, cancellationToken);

        return book.Id;
    }
}
