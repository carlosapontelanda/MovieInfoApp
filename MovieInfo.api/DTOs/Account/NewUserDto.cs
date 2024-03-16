using System.ComponentModel.DataAnnotations; 

namespace MovieInfo.api.DTOs;

public class NewUserDto
{
	public string UserName { get; set; }
	public string Email { get; set; }
	public string Token { get; set; } 
}