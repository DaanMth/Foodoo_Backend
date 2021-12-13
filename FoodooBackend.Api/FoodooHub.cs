using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodooBackend.Data;
using FoodooBackend.Logic;
using FoodooBackend.Models.ApiModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace FoodooBackend.Api
{
    public class FoodooHub : Hub
    {
        private RecipeLogic _recipeLogic;

        public FoodooHub(FoodooContext context)
        {
            _recipeLogic = new RecipeLogic(new RecipeData(context));
        }

        public async Task RecipePosted()
        {
            List<ApiRecipeUpload> recipes = _recipeLogic.GetRecipes();
            Console.WriteLine(recipes.Count);
            await Clients.All.SendAsync("NewRecipePosted", recipes);
        }
    }
}