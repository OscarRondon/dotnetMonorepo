using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Series_101_5_0_webapi.Models;
using System.Net.Mime;

namespace Series_101_5_0_webapi.Controllers
{
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private Recipe[] recipes = { 
            new Recipe() {Title = "Fried Chicken" },
            new Recipe() {Title = "Sushi" },
            new Recipe() {Title = "Pizza" }
        };

        /// <summary>
        /// Get all recipes
        /// </summary>
        /// <returns>List of recipes</returns>
        /// <remarks>
        /// Example:
        /// 
        /// GET https://localhost:port/Recipes
        /// 
        /// </remarks>
        [HttpGet("/[controller]",Name = "GetRecipesAll", Order = 0)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get()
        {
            if (!recipes.Any())
                return NotFound();
            return Ok(recipes) ;
        }

        [HttpGet("/[controller]({id:int})", Name = "GetRecipesById", Order = 1)]
        public ActionResult GetById(int id)
        {
            if (!recipes.Any())
                return NotFound();
            return Ok(recipes[id]);
        }

        [HttpDelete("/[controller]({id:int})", Name = "DeleteRecipe", Order = 2)]
        public ActionResult Delete(int id)
        {
            bool deleted = false;

            if (deleted)
                return BadRequest();
            return NoContent();
        }

        /// <summary>
        /// Update a recipe
        /// </summary>
        /// <returns>List of recipes</returns>
        /// <remarks>
        /// Example:
        ///
        ///     PATCH https://localhost:port/Recipes(125)
        ///     {
        ///        "path": "/title",
        ///        "op": "replace",
        ///        "value": "The new title!!!"
        ///     }
        ///     
        /// </remarks>
        [HttpPatch("/[controller]({id:int})", Name = "UpdateRecipe", Order = 3)]
        public ActionResult Update(int id, JsonPatchDocument<Recipe> recipesUpdate)
        {
            Recipe recipe = recipes[id]; //<- Here we ha have to go to the storage and get de object

            if (recipe == null)
                return NotFound();

            recipesUpdate.ApplyTo(recipe);
            // here we have to update in de storage

            return NoContent();
        }
    }
}
