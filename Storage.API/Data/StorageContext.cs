using Microsoft.EntityFrameworkCore;
using Storage.API.Entities;

namespace Storage.API.Data;

public class StorageContext(DbContextOptions<StorageContext> options) : DbContext(options)
{
  public DbSet<Product> Product { get; set; } = default!;
  public DbSet<Order> Order { get; set; } = default!;
  public DbSet<OrderItem> OrderItem { get; set; } = default!;
  public DbSet<Customer> Customer { get; set; } = default!;
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Indexes
    modelBuilder.Entity<Product>().HasIndex(p => p.Id);
    modelBuilder.Entity<OrderItem>().HasIndex(i => new { i.OrderId, i.ProductId }).IsUnique();
    modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();

    // Delete behaviour
    modelBuilder.Entity<OrderItem>().HasOne(i => i.Order).WithMany(o => o.Items).HasForeignKey(i => i.OrderId).OnDelete(DeleteBehavior.Cascade);
    modelBuilder.Entity<OrderItem>().HasOne(i => i.Product).WithMany().HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.SetNull);
  }
}
