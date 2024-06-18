using api.Data;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

      var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
      var accountGroup = new AccountGroup
      {
        Accounts = accounts,
        AccessToken = "test_token_lygsiaethecgu",
      };

      if (user.AccountGroups == null)
      {
          user.AccountGroups = new List<AccountGroup>();
      }

      user.AccountGroups.Add(accountGroup);

      var result = await _context.SaveChangesAsync() > 0;

      if (!result)
      {
        return BadRequest("Failed to save accounts");
      }

      return Ok(accounts);
    }
  }
}