using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Services;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly TellerService _tellerService;
        private readonly IMapper _mapper;
        public AccountController(DataContext context, TellerService tellerService, IMapper mapper)
        {
            _context = context;
            _tellerService = tellerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accountDtos = await _tellerService.GetAccountsAsync();
            
            var accounts = _mapper.Map<List<Account>>(accountDtos);
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