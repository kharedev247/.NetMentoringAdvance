using Microsoft.AspNetCore.Mvc;
using Task2.BAL.Cart;

namespace Task2.Controllers
{
    /// <summary>
    /// Perform operations related to the Cart V2
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/{V:apiVersion}/[controller]")]
    public class CartingV2Controller : ControllerBase
    {
        private readonly ILogger<CartingV2Controller> _logger;
        private readonly ICartService _cartService;
        
        public CartingV2Controller(ILogger<CartingV2Controller> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }

        /// <summary>
        /// Get Cart Information
        /// </summary>
        /// <param name="cartId">Cart Id</param>
        /// <returns>List of Items in the cart</returns>
        [HttpGet("{cartId}")]
        public IActionResult GetCartInfo(string cartId)
        {
            try
            {
                var cartItems = _cartService.GetCartItems(cartId);
                return Ok(cartItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartingV2Controller.GetCartInfo");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
