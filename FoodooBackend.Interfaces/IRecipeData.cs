using System;
using System.Collections.Generic;
using FoodooBackend.Models.DataModels;

namespace FoodooBackend.Interfaces
{
    public interface IRecipeData
    {
        void AddRecipe(RecipeModel recipeModel);

        List<RecipeModel> GetAll();

        void DeleteRecipe(string id);

        RecipeModel GetRecipeById(string id);
    }
}