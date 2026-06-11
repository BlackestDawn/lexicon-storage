namespace Storage.API.Models;

public class OrderItemDto
{
  public int Id { get; set; }
  public ProductDto? Product { get; set; }
  public int Count { get; set; } = 1;
  public decimal Price { get; set; }
  public decimal DiscountFixed { get; set; } = 0;
  public decimal DiscountPercent { get; set; } = 0;
  public string? Notes { get; set; } = string.Empty;
  public decimal SubTotal => (Price - DiscountFixed) * Count * (1 - DiscountPercent);
}
