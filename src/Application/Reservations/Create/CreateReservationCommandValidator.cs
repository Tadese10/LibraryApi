using FluentValidation;

namespace Application.AppReservation.Create;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
