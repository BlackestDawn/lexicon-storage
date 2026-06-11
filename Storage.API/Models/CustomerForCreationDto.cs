using System.ComponentModel.DataAnnotations;

namespace Storage.API.Models;

public class CustomerForCreationDto
{
  public bool IsActive { get; set; } = true;
  [Required]
  [StringLength(50, MinimumLength = 3)]
  public string Name { get; set; } = string.Empty;
  [Required]
  [EmailAddress]
  public string Email { get; set; } = string.Empty;
  [Required]
  [Phone]
  public string Phone { get; set; } = string.Empty;
  public string? Address { get; set; } = string.Empty;
  public string? City { get; set; } = string.Empty;
  public string? State { get; set; } = string.Empty;
  [DataType(DataType.PostalCode)]
  public int? Zip { get; set; }
  public string? Country { get; set; } = string.Empty;
  [MaxLength(1000)]
  [DataType(DataType.MultilineText)]
  public string? Notes { get; set; } = string.Empty;
}
