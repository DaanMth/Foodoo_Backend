﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FoodooBackend.Data;
using FoodooBackend.Models.ApiModels;
using FoodooBackend.Models.DataModels;
using Microsoft.AspNetCore.Http;

namespace FoodooBackend.Logic
{
    public class RecipeLogic
    {
        private readonly RecipeData _recipeData;
        public RecipeLogic(FoodooContext _context)
        {
            _recipeData = new RecipeData(_context);
        }
        
        public RecipeLogic()
        {
        }

        private void SaveFile(IFormFile uploadedFile, string _path)
        {
            string path = Path.Combine(_path, "Uploads");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            string fileName = Path.GetFileName(uploadedFile.FileName);
            using (FileStream stream =new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                uploadedFile.CopyTo(stream);
            }
        }
        
        public void AddNewRecipe(ApiRecipeUpload upload, IFormFile image, string webRootPath)
        {
            SaveFile(image, webRootPath);
            _recipeData.AddRecipe(new RecipeModel()
            {
                Carbs = upload.Carbs,
                Name = upload.Name,
                Description = upload.Description,
                Image = image.FileName,
                Ingredients = upload.Ingredients,
                Preparation = upload.Preparation
            });
        }
        
        public List<ApiRecipeUpload> GetRecipes()
        {
            return _recipeData.GetAll().Select(model => new ApiRecipeUpload() {Name = model.Name, Carbs = model.Carbs, Description = model.Description, Image = model.Image, Ingredients = model.Ingredients, Preparation = model.Preparation, Id = model.Id}).ToList();
        }

        public void DeleteRecipe(Guid id)
        {
            _recipeData.DeleteRecipe(id);
        }

        public RecipeModel GetRecipeById(string id)
        {
            return _recipeData.GetRecipeById(id);
        }

    }
}