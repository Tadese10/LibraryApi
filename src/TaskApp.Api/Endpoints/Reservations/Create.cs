using Application.AppReservation.Create;
using MediatR;
using SharedKernel;
using TaskApp.Api.Extensions;
using TaskApp.Api.Infrastructure;

namespace TaskApp.Api.Endpoints.Groups;

internal sealed class Create : IEndpoint
{
   
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("Reservations/{bookId}/reserve", async (Guid bookId, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateReservationCommand
            {
                Id = bookId
            };

            Result result = await sender.Send(command, cancellationToken);

            return result;
        })
        .WithTags(Tags.Reservations)
        .RequireAuthorization();
    }
}
