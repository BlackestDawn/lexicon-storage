using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.API.Entities;

public class Order : ITrackable
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  [DataType(DataType.DateTime)]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  [DataType(DataType.DateTime)]
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  public Guid? CustomerId { get; set; }
  [ForeignKey("CustomerId")]
  public Customer? Customer { get; set; }
  [MaxLength(400)]
  public string? Notes { get; set; } = string.Empty;
  public decimal DiscountFixed { get; set; } = 0;
  public decimal DiscountPercent { get; set; } = 0;
  public bool IsPaid { get; set; } = false;
  [DataType(DataType.DateTime)]
  public DateTime? PaidAt { get; set; }
  public bool IsDelivered { get; set; } = false;
  [DataType(DataType.DateTime)]
  public DateTime? DeliveredAt { get; set; }
  public bool IsRefunded { get; set; } = false;
  [DataType(DataType.DateTime)]
  public DateTime? RefundedAt { get; set; }
  public ICollection<OrderItem> Items { get; set; } = [];
  [NotMapped]
  public decimal Total => (Items.Sum(i => i.SubTotal) - DiscountFixed) * (1 - DiscountPercent);
}
