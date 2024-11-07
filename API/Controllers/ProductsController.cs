using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    //add me video 15

    private readonly ILogger<ProductsController> _logger;
    private readonly StoreContext _context;

    public ProductsController(ILogger<ProductsController> logger, StoreContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    [HttpGet("{type}")]
    public async Task<ActionResult<List<Product>>> GetProductByType(string type)
    {
        var list= await _context.Products.Where(p=>p.Type==type).ToListAsync();
        return Ok(list);
    }


}
