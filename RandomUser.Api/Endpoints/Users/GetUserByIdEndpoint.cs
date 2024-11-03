using RandomUser.Api.Common.Api;
using RandomUser.Api.Data.Models;
using RandomUser.Api.Handlers;
using RandomUser.Api.Requests.Users;
using RandomUser.Api.Responses;

namespace RandomUser.Api.Endpoints.Users;

public class GetUserByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Users: Get by id")
            .WithSummary("Returns a user.")
            .WithDescription("Returns a user.")
            .WithOrder(3)
            .Produces<Response<User?>>();

    private static async Task<IResult> HandleAsync(
        UserHandler handler,
        int id)
    {
        var request = new GetUserByIdRequest
        {
            Id = id,
        };
        
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.NotFound(result);
    }
}