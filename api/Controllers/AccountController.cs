using api.Data;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly TellerService _tellerService;
        public AccountController(DataContext context, TellerService tellerService)
        {
            _context = context;
            _tellerService = tellerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _tellerService.GetAccountsAsync();
            
            _context.Accounts.AddRange(accounts);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
            {
                return BadRequest("Failed to save accounts");
            }
            
            return Ok(accounts);
        }


        // implementation of this will be done after implementing the users
        // [HttpGet("tokenGen")]
        // public async Task<IActionResult> GenerateToken()
        // {
        //     var token = new Token
        //     {
        //         AccessToken = "test_token_lygsiaethecgu"
        //     };

        //     _context.Tokens.Add(token);
        //     await _context.SaveChangesAsync();

        //     return Ok();
        // }
    }
}