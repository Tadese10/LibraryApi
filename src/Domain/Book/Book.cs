using SharedKernel;

namespace Domain.Book;

public sealed class Book : Entity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public BookStatus Status { get; set; } = BookStatus.Available;
    public Guid? ReservedBy { get; set; }
    public Guid? BorrowedBy { get; set; }
    public DateTime? ReturnDate { get; set; }
}
