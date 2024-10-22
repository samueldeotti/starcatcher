using Starcatcher.Api.Application.DTO;
using Starcatcher.Domain.Entities;

namespace Starcatcher.Api.Domain.Entities;
public interface IWalletRepository
{

    IEnumerable<WalletDto> GetWallets();
    WalletDto? GetWalletById(int id);
    WalletDto Credit(CreditBalanceWalletDto creditBalanceWalletDto);
    
}