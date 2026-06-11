using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.API.Entities;

public class OrderItem
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  [Required]
  public int OrderId { get; set; }
  [ForeignKey("OrderId")]
  public Order? Order { get; set; }
  [Required]
  public int ProductId { get; set; }
  [ForeignKey("ProductId")]
  public Product? Product { get; set; }
  public int Count { get; set; } = 1;
  public decimal Price { get; set; }
  public decimal DiscountFixed { get; set; } = 0;
  public decimal DiscountPercent { get; set; } = 0;
  [MaxLength(400)]
  public string? Notes { get; set; } = string.Empty;
  [NotMapped]
  public decimal SubTotal => (Price - DiscountFixed) * Count * (1 - DiscountPercent);
}
