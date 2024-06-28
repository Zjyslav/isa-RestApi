using Microsoft.AspNetCore.Mvc;

namespace MyRestApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
    {
        await _productRepository.Add(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id },  product);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePutProduct([FromBody] Product product)
    {
        await _productRepository.Update(product);
        return Ok(product);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdatePatchProduct([FromBody] Product product)
    {
        await _productRepository.Update(product);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productRepository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] int id)
    {
        var product = await _productRepository.Get(id);
        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductById([FromRoute] int id)
    {
        var product = await _productRepository.Delete(id);
        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}
