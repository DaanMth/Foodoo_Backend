using System;
using System.Collections.Generic;
using System.Linq;
using FoodooBackend.Models;
using FoodooBackend.Models.ApiModels;
using FoodooBackend.Models.DataModels;

namespace FoodooBackend.Data
{
    public class RecipeData
    {
        private readonly FoodooContext context;

        public RecipeData(FoodooContext _context)
        {
            context = _context;
        }

        public void AddRecipe(RecipeModel recipeModel)
        {
            recipeModel.Id = Guid.NewGuid();
            context.Recipe.Add(recipeModel);
            context.SaveChanges();
        }

        public List<RecipeModel> GetAll()
        {
            return context.Recipe.ToList();
        }

        public void DeleteRecipe(Guid id)
        {
            RecipeModel recipeModel = new RecipeModel() { Id = id };
            context.Recipe.Remove(recipeModel);
            context.SaveChanges();
        }
        public RecipeModel GetRecipeById(string id)
        {
            return context.Recipe
                .FirstOrDefault(r => r.Id.ToString() == id);;
        }
            
    }
}