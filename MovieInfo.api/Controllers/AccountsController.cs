using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
//using MovieInfo.api.Data;
using MovieInfo.api.Mappers;
using MovieInfo.api.DTOs;
using MovieInfo.api.Models;
using MovieInfo.api.Controllers.ActionFilters;
using MovieInfo.api.Services;

namespace MovieInfo.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(UserManager<AppUser> userManager, ITokenService tokenService) : ControllerBase
{
    private readonly UserManager<AppUser> userManager = userManager;
	private readonly ITokenService tokenService = tokenService;

    [HttpPost("Register")]
	[ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
		try
		{
			var appUser = registerDto.ToAppUserFromRegisterDto();
			
			var createdUser = await userManager.CreateAsync(appUser, registerDto.Password);
			
			if (!createdUser.Succeeded)
				return StatusCode(500, createdUser.Errors);
			
			var roleResult = await userManager.AddToRoleAsync(appUser, "User");
			
			if (!roleResult.Succeeded)
				return StatusCode(500, roleResult.Errors);
			
			return Ok
			(
				new NewUserDto 
				{
					UserName = appUser.UserName, 
					Email = appUser.Email, 
					Token = tokenService.CreateToken(appUser)
				}
			);
		}
		catch (Exception ex)
		{
			return StatusCode(500, ex);
		}
    }

}
    

