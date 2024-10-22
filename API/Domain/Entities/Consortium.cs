using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace Starcatcher.Domain.Entities

{
  public class Consortium
  {
    [Key]
    public int ConsortiumId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; } 

    [Required(ErrorMessage = "Description is required")]
    public required string Description { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? ClosedAt { get; set; } = null!;

    public ICollection<Quota>? Quotas { get; set; }

  }
}