using Microsoft.EntityFrameworkCore;
using Storage.API.Models;

namespace Storage.API.Data
{
    public class StorageContext(DbContextOptions<StorageContext> options) : DbContext(options)
    {
    public DbSet<Product> Product { get; set; } = default!;
    }
}
