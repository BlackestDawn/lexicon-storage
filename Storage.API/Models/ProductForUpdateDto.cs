using System.ComponentModel.DataAnnotations;

namespace Storage.API.Models;

public class ProductForUpdateDto
{
  [Required]
  [StringLength(50, MinimumLength = 3)]
  public string Name { get; set; } = string.Empty;
  [Required]
  public decimal Price { get; set; }
  public decimal DiscountFixed { get; set; } = 0;
  public decimal DiscountPercent { get; set; } = 0;
  [Required]
  [StringLength(40, MinimumLength = 3)]
  public string Category { get; set; } = string.Empty;
  [StringLength(10, MinimumLength = 2)]
  public string? Shelf { get; set; }
  [Required]
  public int Count { get; set; }
  [StringLength(200, MinimumLength = 3)]
  public string? Description { get; set; }
}
