using Application.Books.Update;
using FluentValidation;

namespace Application.Books.Create;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Author).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Status).NotEmpty();

    }
}
