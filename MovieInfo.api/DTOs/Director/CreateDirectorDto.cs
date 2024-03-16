using System.ComponentModel.DataAnnotations;

namespace MovieInfo.api.DTOs;

public record CreateDirectorDto
(
	[Required]
	[MaxLength(50, ErrorMessage = "The director name exceded the maximun amount of characters")]
	string Name, 
	
	[Required]
	DateOnly DateOfBirth,

	[Required]
	[MaxLength(1000, ErrorMessage = "Information about director exceded the maximun amount of characters")]	
	string Info
);



