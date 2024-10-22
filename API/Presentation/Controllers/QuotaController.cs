using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starcatcher.Api.Application.DTO;
using Starcatcher.Api.Domain.Repositories;

namespace Starcatcher.Api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class QuotaController(IQuotaRepository quotaRepository) : ControllerBase
    {
        private readonly IQuotaRepository _quotaRepository = quotaRepository;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_quotaRepository.GetAll());
        }

        [HttpGet("consortium/{consortiumId}")]
        public IActionResult GetByConsortiumId(int consortiumId)
        {
            return Ok(_quotaRepository.GetByConsortiumId(consortiumId));
        }

        [HttpGet("{id}")]
        public IActionResult GetQuotaById(int id)
        {
            return Ok(_quotaRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreationQuotaDto quota)
        {
            return Created("", _quotaRepository.Add(quota));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateQuotaDto quota)
        {
            return Ok(_quotaRepository.Update(quota));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _quotaRepository.Delete(id);
            return NoContent();
        }
    }
}