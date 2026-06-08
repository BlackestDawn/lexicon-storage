namespace Storage.API.Models;

public class Product(int id, string name, decimal price, string category, string shelf, int count, string? description)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
  public decimal Price { get; set; } = price;
  public string Category { get; set; } = category;
  public string Shelf { get; set; } = shelf;
  public int Count { get; set; } = count;
  public string? Description { get; set; } = description;
}
