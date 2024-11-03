using Microsoft.AspNetCore.Mvc;
using RandomUser.Api.Common.Api;
using RandomUser.Api.Data.Models;
using RandomUser.Api.Handlers;
using RandomUser.Api.Requests.Users;
using RandomUser.Api.Responses;

namespace RandomUser.Api.Endpoints.Imports;

public class ImportUsersEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/users", HandleAsync)
            .WithName("Imports: Imports users from API")
            .WithSummary("Imports users from API")
            .WithDescription("Imports users from API")
            .WithOrder(1)
            .Produces<PagedResponse<List<User>?>>();

    private static async Task<IResult> HandleAsync(
        FetchUserHandler fetchUserHandler,
        UserHandler handler,
        [FromQuery] int quantity = Configuration.DefaultQuantity,
        [FromQuery] string nationality = Configuration.DefaultNationality)

    {
        var request = new ImportUsersRequest
        {
            Quantity = quantity,
            Nationality = nationality
        };

        var userResponse = await fetchUserHandler.FetchUsersAsync(request);

        if (!userResponse.IsSuccess || userResponse.Data is null)
            return TypedResults.BadRequest(userResponse);

        var result = await handler.CreateUsersAsync(userResponse.Data);

        return result.IsSuccess
            ? TypedResults.Ok(result.Data)
            : TypedResults.BadRequest(result);
    }
}