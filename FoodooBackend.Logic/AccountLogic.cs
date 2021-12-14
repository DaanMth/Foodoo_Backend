using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FoodooBackend.Data;
using FoodooBackend.Interfaces;
using FoodooBackend.Models;
using FoodooBackend.Models.ApiModels;

namespace FoodooBackend.Logic
{
    public class AccountLogic
    {
        private readonly IAccountData _accountData;

        public AccountLogic(IAccountData accountData)
        {
            _accountData = accountData;
        }
        public string Register(ApiAccount apiAccount)
        {
            Account account = new Account(apiAccount.Email, apiAccount.Username, apiAccount.Password);
            if (_accountData.GetAccountByEmail(apiAccount.Email) != null)
                return "Email taken";
            if (_accountData.GetAccountByUsername(apiAccount.Username) != null)
                return "Username taken";
            
            _accountData.Register(account);
            return "success";
        }

        public string Login(ApiAccount apiAccount)
        {
            Account account = _accountData.GetAccountByEmail(apiAccount.Email);
            if (account.Password != null && account.ValidatePassword(apiAccount.Password))
            {
                return AuthenticationLogic.GenerateToken(account.Id.ToString(), account.Username, account.Email);
            }
            else
            {
                return "wrong password or username";
            }

        }

        public async Task<Account> GoogleAuth(string token)
        {
            Account googleAccount = await _accountData.GetGoogleAuthDataAsync(token);
            if (googleAccount.Username != null)
            {
                Account checkGoogleAccount = await _accountData.GoogleAuthSelectAData(googleAccount.Username, googleAccount.Email);
                if (checkGoogleAccount != null)
                {
                    return checkGoogleAccount;
                }
                else
                {
                    googleAccount.Id = Guid.NewGuid();
                    Account account = await _accountData.GoogleAuthInsertAccount(googleAccount);
                    return account;
                }
            }
            else
            {
                Account emptyAccount = new Account();
                return emptyAccount;
            }
            
        }
    }
}