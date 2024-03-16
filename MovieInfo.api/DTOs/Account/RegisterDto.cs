using System.ComponentModel.DataAnnotations; 

namespace MovieInfo.api.DTOs;

public record RegisterDto
( 
	[Required]
	string UserName,
	
	[Required]
	[EmailAddress]
	string Email,

	[Required]
	string Password
);