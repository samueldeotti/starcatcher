using Starcatcher.Api.Application.DTO;
using Starcatcher.Api.Domain.Repositories;
using Starcatcher.Domain.Entities;
using Starcatcher.Infrastructure.Data;

namespace Starcatcher.Api.Infrastructure.Repositories
{
    public class QuotaRepository(DatabaseContext context) : IQuotaRepository
    {
        private readonly DatabaseContext _context = context;

        public IEnumerable<QuotaDto> GetAll()
        {
            return _context.Quotas.Select(QuotaDto.FromEntity).ToList();
        }

        public IEnumerable<QuotaDto> GetByConsortiumId(int consortiumId)
        {
            bool consortiumExists = _context.Consortia.Any(c => c.ConsortiumId == consortiumId);
            if (!consortiumExists) throw new Exception("Consortium not found");

            return _context.Quotas.Where(q => q.ConsortiumId == consortiumId).Select(QuotaDto.FromEntity).ToList();
        }

        public QuotaDto? GetById(int id)
        {
            return QuotaDto.FromEntity(_context.Quotas.FirstOrDefault(q => q.QuotaId == id)
                ?? throw new Exception("Quota not found"));
        }

        public QuotaDto Add(CreationQuotaDto quota)
        {
            Quota? existingQuota = _context.Quotas.FirstOrDefault(q => q.QuotaNumber == quota.QuotaNumber);

            if (existingQuota != null) throw new Exception("Quota number already in use");

            Consortium consortium = _context.Consortia.FirstOrDefault(c => c.ConsortiumId == quota.ConsortiumId) 
                ?? throw new Exception("Consortium not found");

            if (consortium.ClosedAt != null) throw new Exception("Consortium is closed");

            var newQuota = _context.Quotas.Add(quota.ToEntity());
            _context.SaveChanges();
            return QuotaDto.FromEntity(newQuota.Entity);
        }

        public QuotaDto Update(UpdateQuotaDto quota)
        {
            Quota? existingQuota = _context.Quotas.FirstOrDefault(q => q.QuotaId == quota.QuotaId)
                ?? throw new Exception("Quota not found");

            if (existingQuota.QuotaNumber != quota.QuotaNumber)
            {
                Quota? existingQuotaByQuotaNumber = _context.Quotas.FirstOrDefault(q => q.QuotaNumber == quota.QuotaNumber);
                if (existingQuotaByQuotaNumber != null) throw new Exception("Quota number already in use");
            }

            Consortium consortium = _context.Consortia.FirstOrDefault(c => c.ConsortiumId == quota.ConsortiumId) 
                ?? throw new Exception("Consortium not found");

            if (consortium.ClosedAt != null) throw new Exception("Consortium is closed");

            existingQuota.QuotaNumber = quota.QuotaNumber;
            existingQuota.Value = quota.Value;
            existingQuota.Status = quota.Status;
            existingQuota.UpdatedAt = DateTime.Now;
            existingQuota.ConsortiumId = quota.ConsortiumId;

            _context.SaveChanges();
            return QuotaDto.FromEntity(existingQuota);
        }

        public void Delete(int id)
        {
            Quota? existingQuota = _context.Quotas.FirstOrDefault(q => q.QuotaId == id)
                ?? throw new Exception("Quota not found");

            existingQuota.DeletedAt = DateTime.Now;

            _context.Quotas.Update(existingQuota);
            _context.SaveChanges();
        }
    }
}