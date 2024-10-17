using SharedKernel;

namespace Domain.Book;

public static class BookItemErrors
{
    public static Error NotFound(Guid Id) => Error.NotFound(
        "BookItem.NotFound",
        $"The Book with the Id = '{Id}' was not found");
}
