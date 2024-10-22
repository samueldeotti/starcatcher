using System.ComponentModel.DataAnnotations;

namespace Starcatcher.Api.Application.DTO;

public class LoginDTORequest
{
  [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email format")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(3, ErrorMessage = "Password is too short")]
    public required string Password { get; set; }
}

public class LoginDTOResponse
{
    public string? Token { get; set; }
}