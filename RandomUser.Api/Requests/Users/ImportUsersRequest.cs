using Microsoft.AspNetCore.Authorization;

namespace RandomUser.Api.Requests.Users;

public class ImportUsersRequest
{
    public int Quantity { get; set; }
    public string Nationality { get; set; } = Configuration.DefaultNationality;
}