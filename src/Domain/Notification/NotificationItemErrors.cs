using SharedKernel;

namespace Domain.Notification;

public static class ReservationItemErrors
{
    public static Error NotFound(Guid Id) => Error.NotFound(
        "Notification.NotFound",
        $"The Notification with the Id = '{Id}' was not found");
}
