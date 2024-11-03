using Microsoft.AspNetCore.Mvc;
using RandomUser.Api.Common.Api;
using RandomUser.Api.Data.Models;
using RandomUser.Api.Handlers;
using RandomUser.Api.Requests.Users;
using RandomUser.Api.Responses;

namespace RandomUser.Api.Endpoints.Users;

public class GetAllUsersEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Users: Get All")
            .WithSummary("Returns all of the users.")
            .WithDescription("Returns all of the users.")
            .WithOrder(4)
            .Produces<PagedResponse<List<User>?>>();

    private static async Task<IResult> HandleAsync(
        UserHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllUsersRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.NotFound(result);
    }
}