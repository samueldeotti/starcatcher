using System.ComponentModel.DataAnnotations;
namespace Starcatcher.Domain.Entities
{
  public class Wallet
  {
    [Key]
    public int WalletId { get; set; }
    public decimal Balance { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null!;
    public required int UserId { get; set; }
    public required User User { get; set; }

  }
}