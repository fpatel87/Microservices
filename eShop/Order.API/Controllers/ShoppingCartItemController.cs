using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Services;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemService _shoppingCartItemService;

        public ShoppingCartItemController(
            IShoppingCartItemService shoppingCartItemService)
        {
            _shoppingCartItemService = shoppingCartItemService;
        }

        [HttpDelete("DeleteShoppingCartItemById")]
        public IActionResult DeleteShoppingCartItemById(int id)
        {
            var item = _shoppingCartItemService.GetById(id);

            if (item == null)
                return NotFound();

            _shoppingCartItemService.DeleteItem(id);

            return Ok(new
            {
                Message = "Shopping cart item deleted successfully."
            });
        }
    }
}