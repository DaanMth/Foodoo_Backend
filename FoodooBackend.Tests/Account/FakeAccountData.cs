using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodooBackend.Interfaces;
using FoodooBackend.Models;
using FoodooBackend.Models.ApiModels;

namespace FoodooBackend.Tests
{
    public class FakeAccountData : IAccountData
    {
        List<Account> _account = new List<Account>() {new Account("test@gmail.com", "user", "password" )};
        public void Register(Account account)
        {
            
        }

        public Account GetAccountByEmail(string email)
        {
            return _account.FirstOrDefault(x => x.Email == email);
        }

        public Account GetAccountByUsername(string username)
        {
            return _account.FirstOrDefault(x => x.Username == username);
        }

        public Task<Account> GetGoogleAuthDataAsync(string token)
        {
            return null;
        }

        public Task<Account> GoogleAuthSelectAData(string username, string accountEmail)
        {
            return null;
        }

        public Task<Account> GoogleAuthInsertAccount(Account account)
        {
            return null;
        }
    }
}