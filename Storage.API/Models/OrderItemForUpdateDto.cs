namespace Storage.API.Models;

public class OrderItemForUpdateDto
{
  public int Id { get; set; }
  public int ProductId { get; set; }
  public int Count { get; set; } = 1;
  public decimal Price { get; set; }
  public decimal DiscountFixed { get; set; } = 0;
  public decimal DiscountPercent { get; set; } = 0;
  public string? Notes { get; set; } = string.Empty;
}
