using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.API.Entities;

public class Product(string name) : ITrackable
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  [DataType(DataType.DateTime)]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  [DataType(DataType.DateTime)]
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  [Required]
  [StringLength(50, MinimumLength = 3)]
  public string Name { get; set; } = name;
  public decimal Price { get; set; }
  public decimal DiscountFixed { get; set; } = 0;
  public decimal DiscountPercent { get; set; } = 0;
  [Required]
  [StringLength(40, MinimumLength = 3)]
  public string Category { get; set; } = string.Empty;
  [StringLength(10, MinimumLength = 3)]
  public string? Shelf { get; set; }
  public int Count { get; set; }
  [StringLength(200, MinimumLength = 3)]
  public string? Description { get; set; }
}
