using System.ComponentModel.DataAnnotations;
namespace Starcatcher.Domain.Entities
{
  public class User
  {
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name is too long")]
    [MinLength(3, ErrorMessage = "Name is too short")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(3, ErrorMessage = "Password is too short")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email format")]
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null!;

    public Wallet? Wallet { get; set; } = null!;
    public ICollection<Quota>? Quotas { get; set; } = [];

  }
}