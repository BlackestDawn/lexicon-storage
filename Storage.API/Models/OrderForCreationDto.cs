namespace Storage.API.Models;

public class OrderForCreationDto
{
  public string? Notes { get; set; } = string.Empty;
  public decimal DiscountFixed { get; set; } = 0;
  public decimal DiscountPercent { get; set; } = 0;
  public bool IsPaid { get; set; } = false;
  public DateTime? PaidAt { get; set; }
  public ICollection<OrderItemForCreationDto> Items { get; set; } = [];
}
