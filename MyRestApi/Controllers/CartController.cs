using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyRestApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddCart([FromBody] Cart cart)
    {
        await _cartRepository.Add(cart);
        return CreatedAtAction(nameof(GetCartById), new { id = cart.Id }, cart);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePutCart([FromBody] Cart cart)
    {
        await _cartRepository.Update(cart);
        return Ok(cart);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdatePatchCart([FromBody] Cart cart)
    {
        await _cartRepository.Update(cart);
        return Ok(cart);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCarts()
    {
        var carts = await _cartRepository.GetAll();
        return Ok(carts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCartById([FromRoute] int id)
    {
        var cart = await _cartRepository.Get(id);
        if (cart is null)
        {
            return NotFound();
        }
        return Ok(cart);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCartById([FromRoute] int id)
    {
        var cart = await _cartRepository.Delete(id);
        if (cart is null)
        {
            return NotFound();
        }
        return Ok(cart);
    }

}
