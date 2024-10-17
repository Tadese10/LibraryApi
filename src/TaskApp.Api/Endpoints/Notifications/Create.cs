using Application.Notify.Create;
using Application.Books.Create;
using Domain.Book;
using Domain.Notification;
using MediatR;
using SharedKernel;
using TaskApp.Api.Extensions;
using TaskApp.Api.Infrastructure;

namespace TaskApp.Api.Endpoints.Lists;

internal sealed class Create : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("Notifications/{bookId}/notify", async (Guid bookId, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateNotificationCommand
            {
                BookId = bookId
            };

            Result result = await sender.Send(command, cancellationToken);

            return result;
        })
        .WithTags(Tags.Notifications)
        .RequireAuthorization();
    }
}
