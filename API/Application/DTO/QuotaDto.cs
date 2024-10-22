using System.ComponentModel.DataAnnotations;
using Starcatcher.Domain.Entities;

namespace Starcatcher.Api.Application.DTO
{
  public class CreationQuotaDto
  {
    [Required(ErrorMessage = "Quota number is required")]
    public required string QuotaNumber { get; set; }

    [Required(ErrorMessage = "Value is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Value must be a positive  number")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public required ConsortiumStatus Status { get; set; }

    [Required(ErrorMessage = "ConsortiumId is required")]
    public int ConsortiumId { get; set; }

    public int? UserId { get; set; } = null!;

    public Quota ToEntity()
    {
      return new Quota
      {
        QuotaNumber = QuotaNumber,
        Value = Value,
        Status = Status,
        ConsortiumId = ConsortiumId,
        UserId = UserId
      };
    }
  }

  public class UpdateQuotaDto
  {
    [Required(ErrorMessage = "UserId is required")]
    public int QuotaId { get; set; }

    [Required(ErrorMessage = "Quota number is required")]
    public required string QuotaNumber { get; set; }

    [Required(ErrorMessage = "Value is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Value must be a positive  number")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [EnumDataType(typeof(ConsortiumStatus), ErrorMessage = "Invalid ConsortiumStatus")]
    public required ConsortiumStatus Status { get; set; }

    [Required(ErrorMessage = "ConsortiumId is required")]
    public int ConsortiumId { get; set; }

    public int? UserId { get; set; } = null!;

    public Quota ToEntity()
    {
      return new Quota
      {
        QuotaId = QuotaId,
        QuotaNumber = QuotaNumber,
        Value = Value,
        Status = Status,
        ConsortiumId = ConsortiumId,
        UserId = UserId
      };
    }
  }

  public class QuotaDto
  {
    public int QuotaId { get; set; }
     public required string QuotaNumber { get; set; } 
    public decimal Value { get; set; }
     public required ConsortiumStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required int ConsortiumId { get; set; }
    public int? UserId { get; set; } = null!;

    public static QuotaDto FromEntity(Quota user)
    {
      return new QuotaDto
      {
        QuotaId = user.QuotaId,
        QuotaNumber = user.QuotaNumber,
        Value = user.Value,
        Status = user.Status,
        CreatedAt = user.CreatedAt,
        UpdatedAt = user.UpdatedAt,
        ConsortiumId = user.ConsortiumId,
        UserId = user?.UserId
      };
    }

  }

}