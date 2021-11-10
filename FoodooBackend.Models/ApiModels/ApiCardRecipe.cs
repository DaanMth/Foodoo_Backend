using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FoodooBackend.Models.ApiModels
{
    public class ApiCardRecipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}