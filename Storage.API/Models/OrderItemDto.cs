using Storage.API.Entities;

namespace Storage.API.Models;

public class OrderItemDto
{
  public Product? Product { get; set; }
  public int Count { get; set; }
  public decimal Price { get; set; }
  public string? ExtraInfo { get; set; } = string.Empty;
  public decimal SubTotal => Price * Count;
}
