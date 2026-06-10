using System.ComponentModel.DataAnnotations;

namespace Storage.API.Models;

public class ProductForUpdateDto(string name, decimal price, string category, string? shelf, int count, string? description)
{
  [Required]
  [StringLength(50, MinimumLength = 3)]
  public string Name { get; set; } = name;
  [Required]
  public decimal Price { get; set; } = price;
  [Required]
  [StringLength(40, MinimumLength = 3)]
  public string Category { get; set; } = category;
  [StringLength(10, MinimumLength = 3)]
  public string? Shelf { get; set; } = shelf;
  [Required]
  public int Count { get; set; } = count;
  [StringLength(200, MinimumLength = 3)]
  public string? Description { get; set; } = description;
}
