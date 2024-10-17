using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Domain.Book;
using Domain.Notification;
using Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using System.Net;

namespace Application.Notify.Create;

internal sealed class CreateNotificationCommandHandler(IBookRepository repository, INotificationRepository nrepository, IHttpContextAccessor accessor)
    : ICommandHandler<CreateNotificationCommand>
{
    public async Task<Result> Handle(CreateNotificationCommand command, CancellationToken cancellationToken)
    {

        Book? book = await repository.FindOneAsync(d =>d.Id == command.BookId, cancellationToken);
        if (book == null)
        {
            return Result.Failure(BookItemErrors.NotFound(command.BookId));
        }

        var UserId = Guid.Parse(accessor.HttpContext.Items[Constants.UserIDKey]?.ToString() ?? Guid.Empty.ToString());

        var notification = new Notification
        {
            BookId = command.BookId,
            UserId = UserId
        };

        await nrepository.AddAsync(notification, cancellationToken);

        return Result.Success("Notification will be sent when the book is available.");

    }
}
