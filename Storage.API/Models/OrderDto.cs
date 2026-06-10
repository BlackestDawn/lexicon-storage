namespace Storage.API.Models;

public class OrderDto
{
  public int Id { get; set; }
  public DateTime Created { get; set; } = DateTime.Now;
  public ICollection<OrderItemDto> Items { get; set; } = [];
  public decimal Total => Items.Sum(i => i.SubTotal);
}
