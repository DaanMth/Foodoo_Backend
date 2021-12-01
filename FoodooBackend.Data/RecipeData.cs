using System;
using System.Collections.Generic;
using System.Linq;
using FoodooBackend.Interfaces;
using FoodooBackend.Models;
using FoodooBackend.Models.ApiModels;
using FoodooBackend.Models.DataModels;

namespace FoodooBackend.Data
{
    public class RecipeData : IRecipeData
    {
        private readonly FoodooContext _context;

        public RecipeData(FoodooContext context)
        {
            _context = context;
        }

        public void AddRecipe(RecipeModel recipeModel)
        {
            recipeModel.Id = Guid.NewGuid();
            _context.Recipe.Add(recipeModel);
            _context.SaveChanges();
        }

        public List<RecipeModel> GetAll()
        {
            return _context.Recipe.ToList();
        }

        public void DeleteRecipe(string id)
        {
            _context.Recipe.Remove(GetRecipeById(id));
            _context.SaveChanges();
        }

        public RecipeModel GetRecipeById(string id)
        {
            return _context.Recipe
                .FirstOrDefault(r => r.Id.ToString() == id);
            ;
        }

    }
}