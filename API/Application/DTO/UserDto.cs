using System.ComponentModel.DataAnnotations;
using Starcatcher.Domain.Entities;

namespace Starcatcher.Api.Application.DTO
{
  public class CreationUserDto
  {
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name is too long")]
    [MinLength(3, ErrorMessage = "Name is too short")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email format")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(3, ErrorMessage = "Password is too short")]
    public required string Password { get; set; }

    public User ToEntity()
    {
      return new User
      {
        Name = Name,
        Email = Email,
        Password = Password
      };
    }
  }

  public class UpdateUserDto
  {
    [Required(ErrorMessage = "UserId is required")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name is too long")]
    [MinLength(3, ErrorMessage = "Name is too short")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email format")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(3, ErrorMessage = "Password is too short")]
    public required string Password { get; set; }

    public User ToEntity()
    {
      return new User
      {
        UserId = UserId,
        Name = Name,
        Email = Email,
        Password = Password
      };
    }
  }

  public class UserDto
  {
    public int UserId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int WalletId { get; set; }
    public ICollection<Quota>? Quotas { get; set; }

    public static UserDto FromEntity(User user)
    {
      return new UserDto
      {
        UserId = user.UserId,
        Name = user.Name,
        Email = user.Email,
        CreatedAt = user.CreatedAt,
        DeletedAt = user.DeletedAt,
        WalletId = user.Wallet.WalletId,
        Quotas = user.Quotas
      };
    }

  }

}