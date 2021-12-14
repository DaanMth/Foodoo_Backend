using System;
using System.Linq;
using System.Threading.Tasks;
using FoodooBackend.Interfaces;
using FoodooBackend.Models;
using FoodooBackend.Models.ApiModels;
using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Account> GetGoogleAuthDataAsync(string token)
        {
            var validPayload = await GoogleJsonWebSignature.ValidateAsync(token);
            if (validPayload != null)
            {
                Account googleAccount = new Account();
                googleAccount.Email = validPayload.Email;
                googleAccount.Username = validPayload.Name;
                return googleAccount;
            }

            Account fakeAccount = new Account();
            return fakeAccount;
        }
        
        public async Task<Account> GoogleAuthSelectAData(string username, string accountEmail)
        {
            Account googleAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == accountEmail && x.Username == username);
            return googleAccount;
        }

        public async Task<Account> GoogleAuthInsertAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }
    }
}