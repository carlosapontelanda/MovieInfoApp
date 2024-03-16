using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using MovieInfo.api.Models;

namespace MovieInfo.api.Services;

public class TokenService : ITokenService
{
	private readonly IConfiguration _config;
	private readonly SymmetricSecurityKey _key;
	
	public TokenService(IConfiguration config)
	{
		_config = config;
		_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
	}
	
	public string CreateToken(AppUser appUser)
	{
		var claims = new List<Claim>
		{
				new Claim(JwtRegisteredClaimNames.Email, appUser.Email),
				new Claim(JwtRegisteredClaimNames.GivenName, appUser.UserName)
		};
		
		var credential = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
		
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.Now.AddDays(2),
			SigningCredentials = credential,
			Issuer = _config["JWT:Issuer"],
			Audience = _config["JWT:Audience"]
		};
		
		var tokenHandler = new JwtSecurityTokenHandler();
		
		var token = tokenHandler.CreateToken(tokenDescriptor);
		
		return tokenHandler.WriteToken(token);
		
	}
}