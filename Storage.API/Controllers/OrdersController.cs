using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.API.Data;
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
}
