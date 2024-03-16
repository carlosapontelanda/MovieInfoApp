using System.ComponentModel.DataAnnotations;

namespace MovieInfo.api.DTOs;

public record UpdateDirectorDto
(
	[Required]
	int Id,
	
	[Required]
	[MinLength(2, ErrorMessage = "The director's name must have at least two characters")]
	[MaxLength(50, ErrorMessage = "The director's name exceded the maximun amount of characters")]
	string Name, 
	
	[Required]
	DateOnly DateOfBirth,

	[Required]
	[MinLength(2, ErrorMessage = "The directo's info must have at least 2 characters")]
	[MaxLength(1000, ErrorMessage = "Information about director exceded the maximun amount of characters")]	
	string Info
);


