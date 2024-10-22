using Starcatcher.Api.Application.DTO;
using Starcatcher.Domain.Entities;

namespace Starcatcher.Api.Domain.Repositories
{
    public interface IQuotaRepository
    {
        IEnumerable<QuotaDto> GetAll();
        IEnumerable<QuotaDto> GetByConsortiumId(int consortiumId);
        QuotaDto? GetById(int id);
        QuotaDto Add(CreationQuotaDto quota);
        QuotaDto Update(UpdateQuotaDto quota);
        void Delete(int id);
    }
}