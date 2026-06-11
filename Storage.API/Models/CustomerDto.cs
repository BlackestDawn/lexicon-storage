namespace Storage.API.Models;

public class CustomerDto
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  public bool IsActive { get; set; } = true;
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public string? Address { get; set; } = string.Empty;
  public string? City { get; set; } = string.Empty;
  public string? State { get; set; } = string.Empty;
  public int? Zip { get; set; }
  public string? Country { get; set; } = string.Empty;
  public string? Notes { get; set; } = string.Empty;
  public ICollection<OrderDto> Orders { get; set; } = [];
}
