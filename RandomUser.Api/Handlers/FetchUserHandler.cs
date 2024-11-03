using System.Web;
using RandomUser.Api.Data;
using RandomUser.Api.Data.Models.UsersExternals;
using RandomUser.Api.Requests.Users;
using RandomUser.Api.Responses;

namespace RandomUser.Api.Handlers;

public class FetchUserHandler(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Configuration.HttpRandonUserName);

    public async Task<PagedResponse<List<CreateUserRequest>?>> FetchUsersAsync(ImportUsersRequest request)
    {
        try
        {
            var url = BuildUrl(request);
            var response = await _httpClient.GetFromJsonAsync<Root>(url);

            if (response?.Results is null)
                return new PagedResponse<List<CreateUserRequest>?>(null, 404, "Usuários não encontrados");

            var users = response.Results.Select(user => new CreateUserRequest
            {
                Name = user.Name?.ToString() ?? string.Empty,
                Email = user.Email?.ToString() ?? string.Empty,
                Gender = user.Gender?.ToString() ?? string.Empty,
                BirthDate = user.Dob?.Date,
                Nationality = user.Location?.Country ?? string.Empty,
                Address = user.Location?.ToString() ?? string.Empty,
                Phone = user.Phone ?? string.Empty,
                Mobile = user.Cell ?? string.Empty
            }).ToList();

            return new PagedResponse<List<CreateUserRequest>?>(users, 200, "Usuários importados com sucesso");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new PagedResponse<List<CreateUserRequest>?>(null, 500, "Não foi possível importar os usuários");
        }
    }
    
    private string BuildUrl(ImportUsersRequest request)
    {
        var uriBuilder = new UriBuilder(Configuration.ApiUrl);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        if (request.Quantity > 0)
            query["results"] = request.Quantity.ToString();

        if (!string.IsNullOrWhiteSpace(request.Nationality))
            query["nat"] = request.Nationality;

        uriBuilder.Query = query.ToString();
        return uriBuilder.ToString();
    }
}