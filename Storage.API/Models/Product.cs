using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.API.Models;

public class Product(int id, string name, decimal price, string category, string? shelf, int count, string? description)
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; } = id;
  [StringLength(50, MinimumLength = 3)]
  public string Name { get; set; } = name;
  public decimal Price { get; set; } = price;
  [StringLength(40, MinimumLength = 3)]
  public string Category { get; set; } = category;
  [StringLength(10, MinimumLength = 3)]
  public string? Shelf { get; set; } = shelf;
  public int Count { get; set; } = count;
  [StringLength(200, MinimumLength = 3)]
  public string? Description { get; set; } = description;
}
