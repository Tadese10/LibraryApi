using Application.Abstractions.Messaging;
using Domain.Book;
using Domain.Notification;

namespace Application.Books.Update;

public sealed class UpdateBookCommand : ICommand<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public BookStatus Status { get; set; }
}
