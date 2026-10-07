using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Services;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(
            IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("GetShoppingCartByCustomerId")]
        public IActionResult GetShoppingCartByCustomerId(int customerId)
        {
            var cart = _shoppingCartService.GetCartByCustomerId(customerId);

            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPost("SaveShoppingCart")]
        public IActionResult SaveShoppingCart([FromBody] ShoppingCart cart)
        {
            _shoppingCartService.AddCart(cart);

            return Ok(cart);
        }

        [HttpDelete("DeleteShoppingCart")]
        public IActionResult DeleteShoppingCart(int id)
        {
            var cart = _shoppingCartService.GetCartByCustomerId(id);

            if (cart == null)
                return NotFound();

            _shoppingCartService.DeleteCart(cart.Id);

            return Ok(new
            {
                Message = "Shopping cart deleted successfully."
            });
        }
    }
}