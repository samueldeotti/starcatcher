using System.ComponentModel.DataAnnotations;
using Starcatcher.Domain.Entities;

namespace Starcatcher.Api.Application.DTO;

public class WalletDto
{
  public int WalletId { get; set; }
  public decimal Balance { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
  public DateTime? DeletedAt { get; set; }
  public int UserId { get; set; }

  public static WalletDto FromEntity(Wallet wallet)
  {
    return new WalletDto
    {
      WalletId = wallet.WalletId,
      Balance = wallet.Balance,
      CreatedAt = wallet.CreatedAt,
      UpdatedAt = wallet.UpdatedAt,
      DeletedAt = wallet.DeletedAt,
      UserId = wallet.UserId
    };
  }

}

public class CreditBalanceWalletDto
{
  [Required]
  [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
  public decimal Amount { get; set; }
  [Required]
  public int WalletId { get; set; }
}