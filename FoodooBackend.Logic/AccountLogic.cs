using System;
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
        public void Register(ApiAccount apiAccount)
        {
            Account account = new Account(apiAccount.Email, apiAccount.Username, apiAccount.Password);
            _accountData.Register(account);
        }
    }
}