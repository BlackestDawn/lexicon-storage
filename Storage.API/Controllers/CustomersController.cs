using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.API.Data;
using Storage.API.Entities;
using Storage.API.Models;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(
  StorageContext context,
  IMapper mapper
) : ControllerBase
{
  private readonly StorageContext _context = context;

  // GET: api/Customers
  [HttpGet]
  public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
  {
    var customerEntities = await _context.Customer.ToArrayAsync();
    return Ok(mapper.Map<IEnumerable<CustomerDto>>(customerEntities));
  }

  // GET: api/customers/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<CustomerDto>> GetCustomer(Guid id)
  {
    var customer = await _context.Customer.FindAsync(id);

    if (customer == null)
    {
      return NotFound();
    }

    return Ok(mapper.Map<CustomerDto>(customer));
  }
}
