using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.API.Data;
using Storage.API.Entities;
using Storage.API.Models;

namespace Storage.API.Controllers;

[Route("api/users/id/orders")]
[ApiController]
public class OrdersController(
  StorageContext context,
  IMapper mapper
) : ControllerBase
{
  private readonly StorageContext _context = context;

  // GET: api/user/id/orders
  [HttpGet]
  public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
  {
    var orderEntities = await _context.Order.ToArrayAsync();
    return Ok(mapper.Map<IEnumerable<OrderDto>>(orderEntities));
  }

  // GET: api/user/id/orders/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<OrderDto>> GetOrder(int id)
  {
    var order = await _context.Order.FindAsync(id);

    if (order == null)
    {
      return NotFound();
    }

    return Ok(mapper.Map<OrderDto>(order));
  }

  // POST: api/users/id/orders
  [HttpPost]
  public async Task<ActionResult<OrderDto>> PostOrder(OrderForCreationDto order)
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
    _context.Order.Add(orderEntity);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetOrder", new { id = orderEntity.Id }, mapper.Map<OrderDto>(orderEntity));
  }
  // PUT: api/users/id/orders/{id}
  [HttpPut("{id}")]
  public async Task<IActionResult> PutOrder(int id, OrderForUpdateDto order)
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
    mapper.Map(orderEntity, order);

    return NoContent();
  }

  private bool OrderExists(int id)
  {
    return _context.Order.Any(e => e.Id == id);
  }
}
