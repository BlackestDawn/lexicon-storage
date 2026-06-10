using Microsoft.EntityFrameworkCore;
using Storage.API.Entities;

namespace Storage.API.Data
{
    public class StorageContext(DbContextOptions<StorageContext> options) : DbContext(options)
    {
    public DbSet<Product> Product { get; set; } = default!;
    }
}
