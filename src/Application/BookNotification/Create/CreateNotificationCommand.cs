using Application.Abstractions.Messaging;
using Domain.Notification;

namespace Application.Notify.Create;

public sealed class CreateNotificationCommand : ICommand
{
    public Guid BookId { get; set; }
}
