namespace Storage.API.Models;

public class OrderDto
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public string? Notes { get; set; } = string.Empty;
  public decimal DiscountFixed { get; set; } = 0;
  public decimal DiscountPercent { get; set; } = 0;
  public bool IsPaid { get; set; } = false;
  public DateTime? PaidAt { get; set; }
  public bool IsDelivered { get; set; } = false;
  public DateTime? DeliveredAt { get; set; }
  public bool IsRefunded { get; set; } = false;
  public DateTime? RefundedAt { get; set; }
  public ICollection<OrderItemDto> Items { get; set; } = [];
  public decimal Total => (Items.Sum(i => i.SubTotal) - DiscountFixed) * (1 - DiscountPercent);
}
