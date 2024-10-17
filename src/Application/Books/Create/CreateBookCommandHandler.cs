using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Book;
using Domain.Common;
using Domain.Notification;
using Domain.Users;
using Microsoft.AspNetCore.Http;
using SharedKernel;

namespace Application.Books.Create;

internal sealed class CreateBookCommandHandler(IBookRepository bookRepository)
    : ICommandHandler<CreateBookCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var book = new Book
        {
           Author = command.Author,
           Title = command.Title           
        };

        book.Raise(new BookItemCreatedDomainEvent(book.Id));

        await bookRepository.AddAsync(book, cancellationToken);

        return book.Id;
    }
}
