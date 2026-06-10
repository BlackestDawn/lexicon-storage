using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.API.Entities;

public class Order
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public DateTime Created { get; set; } = DateTime.Now;
  public ICollection<OrderItem> Items { get; set; } = [];
  [NotMapped]
  public decimal Total => Items.Sum(i => i.SubTotal);
}
