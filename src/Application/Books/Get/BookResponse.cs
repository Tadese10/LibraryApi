using Domain.Book;
using Domain.Notification;

namespace Application.Books.Get;

public sealed class BookResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public BookStatus Status { get; set; }
    public Guid? ReservedBy { get; set; }
    public Guid? BorrowedBy { get; set; }
    public DateTime? ReturnDate { get; set; }
}
