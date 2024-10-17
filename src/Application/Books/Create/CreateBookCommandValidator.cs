using FluentValidation;

namespace Application.Books.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Author).NotEmpty().MaximumLength(50);
    }
}
