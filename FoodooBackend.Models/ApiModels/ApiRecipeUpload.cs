using System;
using Microsoft.AspNetCore.Http;

namespace FoodooBackend.Models.ApiModels
{
    public class ApiRecipeUpload
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public string Carbs { get; set; }
        public string Image { get; set; }
    }
}