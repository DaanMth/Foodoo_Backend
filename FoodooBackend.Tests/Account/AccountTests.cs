using System;
using NUnit.Framework;
using FoodooBackend.Logic;
using FoodooBackend.Models.DataModels;
using FoodooBackend.Api;
using FoodooBackend.Api.Controllers;
using FoodooBackend.Models;
using FoodooBackend.Models.ApiModels;
using Microsoft.AspNetCore.Http;


namespace FoodooBackend.Tests
{
    public class AccountTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Register_Success()
        {
            //arrange
            AccountLogic logic = new(new FakeAccountData());
            ApiAccount apiAccount = new ApiAccount()
            {
                Username = "name",
                Email = "testing@gmail.com",
                Password = "passwordtest",
            };
            
            //act
            bool result = logic.Register(apiAccount) == "success";

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Regiser_AccountExists()
        {
            //arrange
            AccountLogic logic = new(new FakeAccountData());
            ApiAccount apiAccount = new ApiAccount()
            {
                Username = "otheruser",
                Email = "test@gmail.com",
                Password = "otherpassword",
            };
            
            //act
            bool result = logic.Register(apiAccount) == "Email taken";

            //assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public void Register_NameTaken()
        {
            //arrange
            AccountLogic logic = new(new FakeAccountData());
            ApiAccount apiAccount = new ApiAccount()
            {
                Username = "user",
                Email = "othertest@gmail.com",
                Password = "otherpassword",
            };
            
            //act
            bool result = logic.Register(apiAccount) == "Username taken";

            //assert
            Assert.IsTrue(result);
        }
    }
}