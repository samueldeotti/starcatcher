using Starcatcher.Api.Application.DTO;
using Starcatcher.Api.Domain.Entities;
using Starcatcher.Domain.Entities;
using Starcatcher.Infrastructure.Data;

namespace Starcatcher.Api.Infrastructure.Repositories
{
  public class WalletRepository(DatabaseContext context) : IWalletRepository
  {
    protected readonly DatabaseContext _context = context;
    public IEnumerable<WalletDto> GetWallets()
    {
      return _context.Wallets.Select(WalletDto.FromEntity).ToList();
    }

    public WalletDto? GetWalletById(int id)
    {
      Wallet? wallet = _context.Wallets.FirstOrDefault(w => w.WalletId == id) ?? throw new Exception("Wallet not found");
      return WalletDto.FromEntity(wallet);
    }

    public WalletDto Credit(CreditBalanceWalletDto creditBalanceWalletDto)
    {
      Wallet? wallet = _context.Wallets.FirstOrDefault(w => w.WalletId == creditBalanceWalletDto.WalletId)
        ?? throw new Exception("Wallet not found");

      wallet.Balance += creditBalanceWalletDto.Amount;
      wallet.UpdatedAt = DateTime.Now;
      _context.SaveChanges();
      return WalletDto.FromEntity(wallet);
    }
  }


}