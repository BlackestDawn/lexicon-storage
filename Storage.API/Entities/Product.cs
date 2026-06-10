using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.API.Entities;

public class Product(string name)
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  [Required]
  [StringLength(50, MinimumLength = 3)]
  public string Name { get; set; } = name;
  public decimal Price { get; set; }
  [Required]
  [StringLength(40, MinimumLength = 3)]
  public string Category { get; set; } = string.Empty;
  [StringLength(10, MinimumLength = 3)]
  public string? Shelf { get; set; }
  public int Count { get; set; }
  [StringLength(200, MinimumLength = 3)]
  public string? Description { get; set; }
}
