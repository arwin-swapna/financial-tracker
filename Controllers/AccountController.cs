using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}