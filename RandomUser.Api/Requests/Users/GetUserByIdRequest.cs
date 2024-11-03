using System.ComponentModel.DataAnnotations;

namespace RandomUser.Api.Requests.Users;

public class GetUserByIdRequest : Request
{
    [Required(ErrorMessage = "Id do usuário inválido!")]
    public int Id { get; set; }
}