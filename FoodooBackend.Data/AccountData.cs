using System;
using System.Linq;
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

        public Account GetAccountByEmail(string email)
        {
            return _context.Accounts.FirstOrDefault(x => x.Email == email);
        }
        
        public Account GetAccountByUsername(string username)
        {
            return _context.Accounts.FirstOrDefault(x => x.Email == username);
        }
    }
}