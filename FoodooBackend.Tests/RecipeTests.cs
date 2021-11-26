using NUnit.Framework;
using FoodooBackend.Logic;
using FoodooBackend.Models.DataModels;
using FoodooBackend.Api;
using FoodooBackend.Api.Controllers;


namespace FoodooBackend.Tests
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddRecipe_RightAnswer()
        {
            //Arrange
            RecipeLogic recipeLogic = new RecipeLogic();
            string ExpectedAnswer = "Lasagne";
            string id = "956805e0-0533-4241-9915-b66ef3e59437";

            //Act
            string result = recipeLogic.GetRecipeById(id).Name;

            //Assert
            Assert.AreEqual(ExpectedAnswer, result);
        }

        [Test]
        public void GetRecipes()
        {
            //Arrange
            RecipeController recipeController = new RecipeController();
            string ExpectedAnswer = recipeController.GetPageRecipes().ToString();

            //Act
            string result = recipeController.GetPageRecipes().ToString();

            //Assert
            Assert.AreEqual(ExpectedAnswer, result);
        }
    }
}