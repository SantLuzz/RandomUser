using System.ComponentModel.DataAnnotations;

namespace RandomUser.Api.Requests.Users;

public class CreateUserRequest : Request
{
    [Required(ErrorMessage = "Nome inválido!")]
    [MaxLength(160, ErrorMessage = "O Nome deve conter até 160 caracteres!")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "E-mail obrigátorio!")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    [MaxLength(160, ErrorMessage = "O e-mail deve conter até 160 caracteres!")]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(10, ErrorMessage = "O gênero deve conter até 10 caracteres!")]
    public string Gender { get; set; } = string.Empty;
    
    public DateTime? BirthDate { get; set; }
    
    [MaxLength(50, ErrorMessage = "A nacionálidade deve conter até 50 caracteres!")]
    public string Nationality { get; set; } = string.Empty;
    
    [MaxLength(255, ErrorMessage = "O endereço deve conter até 255 caracteres!")]
    public string Address { get; set; } = string.Empty;
    
    [MaxLength(20, ErrorMessage = "O telefone deve conter até 20 caracteres!")]
    public string Phone { get; set; } = string.Empty;
    
    [MaxLength(20, ErrorMessage = "O celular deve conter até 20 caracteres!")]
    public string Mobile { get; set; } = string.Empty;
}