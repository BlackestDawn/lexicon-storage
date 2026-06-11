using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.API.Data;
using Storage.API.Entities;
using Storage.API.Models;

namespace Storage.API.Controllers;

[Route("api/users/{customerId}/orders")]
[ApiController]
public class OrdersController(
  StorageContext context,
  IMapper mapper
) : ControllerBase
{
  private readonly StorageContext _context = context;

  // GET: api/user/id/orders
  [HttpGet]
  public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(Guid customerId)
  {
    var orderEntities = await _context.Order
      .Where(o => o.CustomerId == customerId)
      .Include(o => o.Items)
      .OrderByDescending(o => o.CreatedAt)
      .ToListAsync();
    return Ok(mapper.Map<IEnumerable<OrderDto>>(orderEntities));
  }

  // GET: api/user/id/orders/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<OrderDto>> GetOrder(Guid customerId, int id)
  {
    var order = await _context.Order
      .Where(o => o.CustomerId == customerId)
      .Include(o => o.Items)
      .FirstOrDefaultAsync(o => o.Id == id);

    if (order == null)
    {
      return NotFound();
    }

    return Ok(mapper.Map<OrderDto>(order));
  }

  // POST: api/users/id/orders
  [HttpPost]
  public async Task<ActionResult<OrderDto>> PostOrder(Guid customerId, OrderForCreationDto order)
  {
    var productIds = order.Items.Select(i => i.ProductId).Distinct().ToList();
    var foundIds = await _context.Product
      .Where(p => productIds.Contains(p.Id))
      .Select(p => p.Id)
      .ToListAsync();

    var missingIds = productIds.Except(foundIds).ToList();
    if (missingIds.Count != 0)
    {
      return BadRequest($"Missing products: {string.Join(", ", missingIds)}");
    }

    var orderEntity = mapper.Map<Order>(order);
    orderEntity.CustomerId = customerId;
    _context.Order.Add(orderEntity);
    await _context.SaveChangesAsync();

    await _context.Entry(orderEntity)
      .Collection(o => o.Items)
      .LoadAsync();

    return CreatedAtAction("GetOrder", new { customerId, id = orderEntity.Id }, mapper.Map<OrderDto>(orderEntity));
  }
  // PUT: api/users/id/orders/{id}
  [HttpPut("{id}")]
  public async Task<IActionResult> PutOrder(Guid customerId, int id, OrderForUpdateDto order)
  {
    if (!OrderExists(id))
    {
      return NotFound();
    }

    var productIds = order.Items.Select(i => i.ProductId).Distinct().ToList();
    var foundIds = await _context.Product
      .Where(p => productIds.Contains(p.Id))
      .Select(p => p.Id)
      .ToListAsync();

    var missingIds = productIds.Except(foundIds).ToList();
    if (missingIds.Count != 0)
    {
      return BadRequest($"Missing products: {string.Join(", ", missingIds)}");
    }

    var orderEntity = await _context.Order.FindAsync(id);
    orderEntity!.CustomerId = customerId;
    mapper.Map(order, orderEntity);

    return NoContent();
  }

  private bool OrderExists(int id)
  {
    return _context.Order.Any(e => e.Id == id);
  }
}
