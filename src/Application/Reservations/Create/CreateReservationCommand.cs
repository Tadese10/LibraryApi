using Domain.Reservation;
using Domain.Notification;
using Application.Abstractions.Messaging;


namespace Application.AppReservation.Create;

public sealed class CreateReservationCommand : ICommand
{
    public Guid Id { get; set; }
}
