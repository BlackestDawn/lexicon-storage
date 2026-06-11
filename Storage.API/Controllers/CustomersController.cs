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

  // POST: api/customers
  [HttpPost]
  public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerForCreationDto customer)
  {
    if (_context.Customer.Any(c => c.Email == customer.Email))
    {
      return BadRequest($"Customer with email {customer.Email} already exists.");
    }

    var customerEntity = mapper.Map<Customer>(customer);
    _context.Customer.Add(customerEntity);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetCustomer", new { id = customerEntity.Id }, mapper.Map<CustomerDto>(customerEntity));
  }

  // POST: api/customers/{id}
  [HttpPut("{id}")]
  public async Task<IActionResult> PutCustomer(Guid id, CustomerForUpdateDto customer)
  {
    var customerEntity = await _context.Customer.FindAsync(id);
    if (customerEntity == null)
    {
      return NotFound();
    }

    if (customerEntity.Email != customer.Email && _context.Customer.Any(c => c.Email == customer.Email))
    {
      return BadRequest($"Can't change email to someone else's email.");
    }

    mapper.Map(customer, customerEntity);
    await _context.SaveChangesAsync();

    return NoContent();
  }
}
