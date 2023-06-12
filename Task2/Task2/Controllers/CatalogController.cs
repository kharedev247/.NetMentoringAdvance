using Microsoft.AspNetCore.Mvc;
using Task2.BAL.Category;
using Task2.BAL.Product;
using Task2.DAL.Entities;
using Task2.Models;
using Task2.RabbitMQ.Producer;
using Response = Task2.Models.Response;

namespace Task2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IRabbitMQProducer _rabbitMqProducer;

        public CatalogController(ILogger<CatalogController> logger, ICategoryService categoryService, IProductService productService, IRabbitMQProducer rabbitMqProducer)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _rabbitMqProducer = rabbitMqProducer;
        }

        [HttpGet("Category")]
        public IActionResult ListCategories()
        {
            var response = new Response();
            try
            {
                var categories = _categoryService.ListCategories();
                response.Body = categories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CatalogController.ListCategories");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return Ok(response);
        }

        [HttpGet("Item")]
        public IActionResult ListItems()
        {
            var response = new Response();
            try
            {
                var items = _productService.ListProducts();
                response.Body = items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CatalogController.ListItems");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return Ok(response);
        }

        [HttpGet("Category/{categoryId}/Items")]
        public IActionResult ListItemsForCategory(int categoryId)
        {
            var response = new Response();
            try
            {
                var items = _productService.ListProductsByCategoryId(categoryId);
                response.Body = items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CatalogController.ListItems");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return Ok(response);
        }

        [HttpPost("Category")]
        public IActionResult AddCategory(Category category)
        {
            var response = new Response();
            try
            {
                _categoryService.AddCategory(category);
                response.Body = "Category added successfully";
                response.Links = CreateLinksForCategory();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CatalogController.AddCategory");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost("Item")]
        public IActionResult AddItem(Product product)
        {
            var response = new Response();
            try
            {
                _productService.AddProduct(product);
                response.Body = "Item added successfully";
                response.Links = CreateLinksForItem();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CatalogController.AddItem");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut("Category/Update")]
        public IActionResult UpdateCategory(Category category)
        {
            var response = new Response();
            try
            {
                _categoryService.UpdateCategory(category);
                response.Body = "Category updated successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CatalogController.UpdateCategory");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return Ok(response);
        }

        [HttpPut("Item/Update")]
        public IActionResult UpdateItem(Product product)
        {
            var response = new Response();
            try
            {
                _productService.UpdateProduct(product);
                _rabbitMqProducer.SendProductMessage(product);
                response.Body = "Item updated successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CatalogController.UpdateItem");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return Ok(response);
        }

        [HttpDelete("Item")]
        public IActionResult DeleteItem(string name)
        {
            var response = new Response();
            try
            {
                _productService.DeleteProduct(name);
                response.Body = "Item deleted successfully";
;            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CatalogController.DeleteItem");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return StatusCode(StatusCodes.Status202Accepted, response);
        }

        [HttpDelete("Category")]
        public IActionResult DeleteCategory(string name)
        {
            var response = new Response();
            try
            {
                _categoryService.DeleteCategory(name);
                response.Body = "Category deleted successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CatalogController.DeleteCategory");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return StatusCode(StatusCodes.Status202Accepted, response);
        }

        private List<Link> CreateLinksForCategory()
        {
            var links = new List<Link>
            {
                new Link("/api/Catalog/Category/Update", "self", "PUT"),
                new Link("/api/Catalog/Category", "self", "DELETE")
            };
            return links;
        }

        private List<Link> CreateLinksForItem()
        {
            var links = new List<Link>
            {
                new Link("/api/Catalog/Item/Update", "self", "PUT"),
                new Link("/api/Catalog/Item", "self", "DELETE")
            };
            return links;
        }
    }
}
