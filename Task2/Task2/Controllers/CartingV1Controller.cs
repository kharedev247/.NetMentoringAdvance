using Microsoft.AspNetCore.Mvc;
using Task2.BAL.Cart;
using Task2.DAL.Entities;

namespace Task2.Controllers
{
    /// <summary>
    /// Perform operations related to the Cart V1
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{V:apiVersion}/[controller]")]
    public class CartingV1Controller : ControllerBase
    {
        private readonly ILogger<CartingV1Controller> _logger;
        private readonly ICartService _cartService;

        public CartingV1Controller(ILogger<CartingV1Controller> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }

        /// <summary>
        /// Get Cart Information
        /// </summary>
        /// <param name="cartId">Cart Id</param>
        /// <returns>Cart information</returns>
        [HttpGet]
        public IActionResult GetCartInfo(string cartId)
        {
            try
            {
                var cart = _cartService.GetCartInfo(cartId);

                return Ok(cart);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartingV1Controller.GetCartInfo");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Add items to the cart
        /// </summary>
        /// <param name="cartId">Cart Id</param>
        /// <param name="cartItem"> Item to be added in cart</param>
        /// <returns></returns>
        [HttpPost("{cartId}")]
        public IActionResult AddItemToCart(string cartId, Product cartItem)
        {
            try
            {
                _cartService.AddItemToCart(cartId, cartItem);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartingV1Controller.AddItemToCart");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Delete items from the cart
        /// </summary>
        /// <param name="cartId">Cart Id</param>
        /// <param name="itemId">Item Id to be deleted</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteItemFromCart(string cartId, int itemId)
        {
            try
            {
                _cartService.DeleteItemFromCart(cartId, itemId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartingV1Controller.DeleteItemFromCart");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
