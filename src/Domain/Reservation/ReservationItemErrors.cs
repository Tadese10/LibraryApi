using SharedKernel;

namespace Domain.Reservation;

public static class ReservationItemErrors
{
    public static Error NotFound(Guid Id) => Error.NotFound(
        "Reservation.NotFound",
        $"The Notification with the Id = '{Id}' was not found");

    public static Error NotAvailable(Guid Id) => Error.NotFound(
       "Reservation.NotAvailable",
       $"The Notification with the Id = '{Id}' is not available");
}
