using System;
using System.Threading.Tasks;
using FoodooBackend.Data;
using FoodooBackend.Logic;
using FoodooBackend.Models;
using FoodooBackend.Models.ApiModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FoodooBackend.Api.Controllers
{
    [EnableCors("AllowCORS")]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly AccountLogic _accountLogic;
        
        public AccountController(FoodooContext context)
        {
            _accountLogic = new AccountLogic(new AccountData(context));
        }

        [HttpPost("/account/register")]
        public void Register(ApiAccount account)
        {
            _accountLogic.Register(account);
        }

        [HttpPost("/account/login")]
        public string Login(ApiAccount account)
        {
            return _accountLogic.Login(account);
        }

        [HttpGet("/account/info/{token}")]
        public IActionResult GetAccountInfo(string token)
        {
                return StatusCode(200, AuthenticationLogic.getAccountInfo(token));
            
        }

        [HttpPost("/googleauth/{token}")]
        public async Task<ActionResult<Account>> GoogleLogin(string token)
        {
            Account account = await _accountLogic.GoogleAuth(token);
            return account;
        }
    }
}