using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Series_101_5_0_webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {

        [HttpGet("Dishes")]
        public string[] Get()
        {
            return new string[] { "Pollo Frito", "Sushi", "Pizza" };
        }

        [HttpGet("Dishes2")]
        public string[] Get(string id)
        {
            return new string[] { "Pollo Frito", "Sushi", "Pizza" };
        }
    }
}
