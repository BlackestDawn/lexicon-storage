using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.API.Data;
using Storage.API.Entities;
using Storage.API.Models;

namespace Storage.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(
  StorageContext context,
  IMapper mapper
) : ControllerBase
{
  private readonly StorageContext _context = context;

  // GET: api/Products
  [HttpGet]
  public async Task<ActionResult<IEnumerable<ProductDto>>> GetProduct()
  {
    var productEntities = await _context.Product.ToListAsync();
    return Ok(mapper.Map<IEnumerable<ProductDto>>(productEntities));
  }

  // GET: api/Products/5
  [HttpGet("{id}")]
  public async Task<ActionResult<ProductDto>> GetProduct(int id)
  {
    var product = await _context.Product.FindAsync(id);

    if (product == null)
    {
      return NotFound();
    }

    return Ok(mapper.Map<ProductDto>(product));
  }

  // PUT: api/Products/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutProduct(int id, ProductForUpdateDto product)
  {
    if (!ProductExists(id))
    {
      return NotFound();
    }

    var productEntity = await _context.Product.FindAsync(id);
    mapper.Map(productEntity, product);

    await _context.SaveChangesAsync();

    return NoContent();
  }

  // POST: api/Products
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<Product>> PostProduct(ProductForCreationDto product)
  {
    var productEntity = mapper.Map<Product>(product);
    _context.Product.Add(productEntity);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetProduct", new { id = productEntity.Id }, productEntity);
  }

  // DELETE: api/Products/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteProduct(int id)
  {
    var product = await _context.Product.FindAsync(id);
    if (product == null)
    {
      return NotFound();
    }

    _context.Product.Remove(product);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool ProductExists(int id)
  {
    return _context.Product.Any(e => e.Id == id);
  }
}
