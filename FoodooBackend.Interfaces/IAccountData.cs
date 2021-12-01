using FoodooBackend.Models;

namespace FoodooBackend.Interfaces
{
    public interface IAccountData
    {
        void Register(Account account);
        Account GetAccountByEmail(string email);
        Account GetAccountByUsername(string username);
    }
}