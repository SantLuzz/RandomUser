using RandomUser.Api.Common.Api;
using RandomUser.Api.Data.Models;
using RandomUser.Api.Handlers;
using RandomUser.Api.Requests.Users;
using RandomUser.Api.Responses;

namespace RandomUser.Api.Endpoints.Users;

public class UpdateUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Users: Update")
            .WithSummary("Updates a user")
            .WithTags("Updates a user")
            .WithOrder(2)
            .Produces<Response<User?>>();
    
    private static async Task<IResult> HandleAsync(
        UserHandler handler,
        UpdateUserRequest request,
        int id)
    {
        request.Id = id;
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result.Data)
            : TypedResults.BadRequest(result);
    }
}