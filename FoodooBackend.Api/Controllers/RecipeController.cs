using System.Collections.Generic;
using FoodooBackend.Data;
using FoodooBackend.Logic;
using FoodooBackend.Models.ApiModels;
using FoodooBackend.Models.DataModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodooBackend.Api.Controllers
{
    [EnableCors("AllowCORS")]
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly FoodooContext _context;
        private readonly RecipeLogic _recipeLogic;
        private IWebHostEnvironment _environment;
        public RecipeController(FoodooContext foodooContext, IWebHostEnvironment environment
        )
        {
            _recipeLogic = new RecipeLogic(new RecipeData(foodooContext));
            _environment = environment;
        }
        
        [HttpGet]
        public List<ApiRecipeUpload> GetPageRecipes()
        {
            return _recipeLogic.GetRecipes();
        }

        [HttpPost("/recipe")]
        public void AddRecipe(IFormCollection collection)
        {
            var image = Request.Form.Files[0];
            
            ApiRecipeUpload model = new()
            {
                Name = collection["name"],
                Carbs = collection["carbs"],
                Description = collection["description"],
                Ingredients = collection["ingredients"],
                Preparation = collection["preparation"]
            };
            _recipeLogic.AddNewRecipe(model, image, _environment.WebRootPath);
            
        }

        [HttpGet("/recipe/{id}")]
        public RecipeModel GetRecipeById(string id)
        {
            return _recipeLogic.GetRecipeById(id);
        }

        [HttpPost("/recipe/delete/{id}")]
        public void DeleteRecipe(string id)
        {
            _recipeLogic.DeleteRecipe(id);
        }
    }
}
