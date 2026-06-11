using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Storage.API.Entities;

namespace Storage.API.Data;

public class UpdatedAtInterceptor : SaveChangesInterceptor
{
  public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
  {
    SetUpdatedAt(eventData.Context);
    return base.SavingChanges(eventData, result);
  }

  public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken ct = default)
  {
    SetUpdatedAt(eventData.Context);
    return base.SavingChangesAsync(eventData, result, ct);
  }

  private static void SetUpdatedAt(DbContext? context)
  {
    if (context is null) return;

    foreach (var entry in context.ChangeTracker.Entries<OrderItem>())
    {
      if (entry.State is EntityState.Modified or EntityState.Added or EntityState.Deleted)
      {
        var order = entry.Entity.Order
          ?? context.ChangeTracker.Entries<Order>()
            .FirstOrDefault(e => e.Entity.Id == entry.Entity.OrderId)?.Entity;

        if (order is not null)
          context.Entry(order).State = EntityState.Modified;
      }
    }

    foreach (var entry in context.ChangeTracker.Entries<ITrackable>())
    {
      if (entry.State == EntityState.Modified)
      {
        entry.Entity.UpdatedAt = DateTime.UtcNow;
      }
    }
  }
}
