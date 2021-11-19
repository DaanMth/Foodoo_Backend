using System;
using FoodooBackend.Interfaces;
using FoodooBackend.Models;
using FoodooBackend.Models.ApiModels;

namespace FoodooBackend.Data
{
    public class AccountData : IAccountData
    {
        private readonly FoodooContext _context;

        public AccountData(FoodooContext context)
        {
            _context = context;
        }
        
        public void Register(Account account)
        {
            account.Id = Guid.NewGuid();
            _context.Accounts.Add(account);
            _context.SaveChanges();
            
        }
    }
}