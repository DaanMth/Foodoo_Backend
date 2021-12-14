using System.Threading.Tasks;
using FoodooBackend.Models;

namespace FoodooBackend.Interfaces
{
    public interface IAccountData
    {
        void Register(Account account);
        Account GetAccountByEmail(string email);
        Account GetAccountByUsername(string username);
        Task<Account> GetGoogleAuthDataAsync(string token);
        Task<Account> GoogleAuthSelectAData(string username, string accountEmail);
        Task<Account> GoogleAuthInsertAccount(Account account);
    }
}