using Domain.DTOs.Cart;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _cartService.GetAllAsync();
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cart = await _cartService.GetByIdAsync(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUpdateCartDto dto)
        {
            var created = await _cartService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateCartDto dto)
        {
            var updated = await _cartService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _cartService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}