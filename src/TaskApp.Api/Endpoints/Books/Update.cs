using Application.Books.Create;
using Application.Books.Update;
using Domain.Book;
using Domain.Notification;
using MediatR;
using SharedKernel;
using TaskApp.Api.Endpoints;
using TaskApp.Api.Extensions;
using TaskApp.Api.Infrastructure;

namespace Web.Api.Endpoints.Tasks;

internal sealed class Update : IEndpoint
{
    public sealed class Request
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookStatus Status { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("Books/{Id}", async (Guid Id, Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new UpdateBookCommand
            {
                Id = Id,
                Status = request.Status,
                Author = request.Author,
                Title = request.Title
            };

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Books)
        .RequireAuthorization();
    }
}
