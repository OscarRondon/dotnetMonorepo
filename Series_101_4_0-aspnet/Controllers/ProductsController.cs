using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Series_101_4_0_aspnet.Models;
using Series_101_4_0_aspnet.Services;

namespace Series_101_4_0_aspnet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductService ProductService { get; }
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId,
            [FromQuery] int Rating
        )
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}
