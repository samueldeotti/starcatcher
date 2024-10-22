using System.ComponentModel.DataAnnotations;
namespace Starcatcher.Domain.Entities
{
    public class Quota
    {
        [Key]
        public int QuotaId { get; set; }

        [Required(ErrorMessage = "Quota number is required")]
        public required string QuotaNumber { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Value must be a positive  number")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [EnumDataType(typeof(ConsortiumStatus), ErrorMessage = "Invalid ConsortiumStatus")]
        public required ConsortiumStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

        [Required(ErrorMessage = "ConsortiumId is required")]
        public required int ConsortiumId { get; set; }
        public Consortium? Consortium { get; set; }

        public int? UserId { get; set; } = null!;
        public User? User { get; set; }

    }

    public enum ConsortiumStatus
    {
        Open,
        Sold,
    }
}