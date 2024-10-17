using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Domain.Reservation;
using Domain.Book;
using Microsoft.AspNetCore.Http;
using SharedKernel;
using ReservationItemErrors = Domain.Reservation.ReservationItemErrors;
using ReservationItemCreatedDomainEvent = Domain.Reservation.ReservationItemCreatedDomainEvent;

namespace Application.AppReservation.Create;

internal sealed class CreateCommandHandler(IBookRepository repository, IReservationRepository rrepository, IHttpContextAccessor accessor)
    : ICommandHandler<CreateReservationCommand>
{
    public async Task<Result> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
    {
        Book? book = await repository.FindOneAsync(d =>d.Id == command.Id, cancellationToken);
        
        if (book == null || book.Status != BookStatus.Available)
        {
            return Result.Failure(ReservationItemErrors.NotAvailable(command.Id));
        }

        book.Status = BookStatus.Reserved;
        book.ReservedBy = Guid.Parse(accessor.HttpContext.Items[Constants.UserIDKey]?.ToString() ?? Guid.Empty.ToString());

        var reservation = new Reservation
        {
            BookId = book.Id,
            UserId = book.ReservedBy.Value,
        };

        await repository.UpdateAsync(book, cancellationToken);

        await rrepository.AddAsync(reservation, cancellationToken);

        reservation.Raise(new ReservationItemCreatedDomainEvent(reservation.Id));

        return Result.Success();

    }
}
