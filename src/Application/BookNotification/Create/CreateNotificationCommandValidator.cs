using FluentValidation;

namespace Application.Notify.Create;

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(c => c.BookId).NotEmpty();
    }
}
