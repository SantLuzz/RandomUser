using RandomUser.Api.Common.Api;
using RandomUser.Api.Endpoints.Imports;
using RandomUser.Api.Endpoints.Users;

namespace RandomUser.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoint = app.MapGroup("");
        
        endpoint.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { Message = "OK" });
        
        endpoint.MapGroup("v1/imports")
            .WithTags("Imports")
            .MapEndpoints<ImportUsersEndpoint>();
        
        endpoint.MapGroup("v1/users")
            .WithTags("Users")
            .MapEndpoints<UpdateUserEndpoint>()
            .MapEndpoints<GetUserByIdEndpoint>()
            .MapEndpoints<GetAllUsersEndpoint>();
    }
    
    private static IEndpointRouteBuilder MapEndpoints<TEndpoint> (this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}