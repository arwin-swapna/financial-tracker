using api.Data;
using api.DTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  public class UserController : BaseApiController
  {
    private readonly UserManager<User> _userManager;
    public readonly TokenService _tokenService;
    public readonly DataContext _context;

    public UserController(UserManager<User> userManager, TokenService tokenService, DataContext context)
    {
      _userManager = userManager;
      _tokenService = tokenService;
      _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(RegisterDto registerDto)
    {
      var user = new User
      {
        UserName = registerDto.Email,
        Email = registerDto.Email
      };

      var result = await _userManager.CreateAsync(user, registerDto.Password);
      if (!result.Succeeded) return BadRequest(result.Errors);

      await _userManager.AddToRoleAsync(user, "Member");

      return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var user = await _userManager.FindByEmailAsync(loginDto.Email);
      if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
      {
        return Unauthorized();
      }

      return new UserDto
      {
        Email = user.Email,
        Token = await _tokenService.GenerateToken(user),
        Role = _userManager.GetRolesAsync(user).ToString(),
        isEmailConfirmed = user.EmailConfirmed
      };

    }
  }
}