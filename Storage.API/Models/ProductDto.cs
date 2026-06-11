namespace Storage.API.Models;

public class ProductDto
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
  public string Name { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public decimal DiscountFixed { get; set; } = 0;
  public decimal DiscountPercent { get; set; } = 0;
  public string Category { get; set; } = string.Empty;
  public string? Shelf { get; set; }
  public int Count { get; set; }
  public string? Description { get; set; }
}
