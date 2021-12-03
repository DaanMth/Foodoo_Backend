using System;
using System.Security.Cryptography;
using System.Text;
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
        
        public static string Encrypt(string password)
        {
            string plainData = password;
            string hashedData = ComputeSha256Hash(plainData);

            return hashedData;
        }
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        public string Register(ApiAccount apiAccount)
        {
            Account account = new Account(apiAccount.Email, apiAccount.Username, Encrypt(apiAccount.Password));
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
            if (account.Password != null && Encrypt(apiAccount.Password) == account.Password)
            {
                return AuthenticationLogic.GenerateToken(account.Id.ToString(), account.Username, account.Email);
            }
            else
            {
                return "wrong password or username";
            }

        }
    }
}