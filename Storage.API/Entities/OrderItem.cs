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
  public int Count { get; set; }
  public decimal Price { get; set; }
  public string? ExtraInfo { get; set; } = string.Empty;
  [NotMapped]
  public decimal SubTotal => Price * Count;
}
