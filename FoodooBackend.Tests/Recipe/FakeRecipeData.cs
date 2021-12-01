using System.Collections.Generic;
using System.Linq;
using FoodooBackend.Interfaces;
using FoodooBackend.Models.DataModels;

namespace FoodooBackend.Tests
{
    public class FakeData : IRecipeData
    {
        List<RecipeModel> _recipes = new List<RecipeModel>();
        public void AddRecipe(RecipeModel recipeModel)
        {
            _recipes.Add(recipeModel);
        }

        public List<RecipeModel> GetAll()
        {
            return _recipes;
        }

        public void DeleteRecipe(string id)
        {
            _recipes.Remove(GetRecipeById(id));
        }

        public RecipeModel GetRecipeById(string id)
        {
            return _recipes.FirstOrDefault(x => x.Id.ToString() == id);
        }
        
    }
}