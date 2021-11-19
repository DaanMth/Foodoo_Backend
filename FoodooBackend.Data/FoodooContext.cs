using FoodooBackend.Models;
using FoodooBackend.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace FoodooBackend.Data
{
    public class FoodooContext : DbContext
    {
        public DbSet<RecipeModel> Recipe { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public FoodooContext(DbContextOptions options) : base(options)
        {
        }

    }
}