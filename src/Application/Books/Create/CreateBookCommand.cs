using Application.Abstractions.Messaging;
using Domain.Book;
using Domain.Notification;

namespace Application.Books.Create;

public sealed class CreateBookCommand : ICommand<Guid>
{
    public string Title { get; set; }
    public string Author { get; set; }
}
