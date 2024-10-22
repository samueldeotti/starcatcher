using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starcatcher.Api.Application.DTO;
using Starcatcher.Api.Domain.Entities;
using Starcatcher.Domain.Entities;

namespace Starcatcher.Api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WalletController(IWalletRepository walletRepository) : ControllerBase
    {
        private readonly IWalletRepository _walletRepository = walletRepository;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_walletRepository.GetWallets());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_walletRepository.GetWalletById(id));
        }

        [HttpPost("credit")]
        public IActionResult Credit([FromBody] CreditBalanceWalletDto creditBalanceWalletDto)
        {
            return Ok(_walletRepository.Credit(creditBalanceWalletDto));
        }


    }
}