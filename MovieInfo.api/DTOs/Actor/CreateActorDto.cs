using System.ComponentModel.DataAnnotations; 

namespace MovieInfo.api.DTOs;

public record CreateActorDto
(
	[Required]
	[MinLength(2, ErrorMessage = "The actor's name must have at least 2 characters")]
	[MaxLength(50, ErrorMessage = "The actor's name exceded the maximun amount of characters")]	
	string Name, 
	
	[Required]
	DateOnly DateOfBirth,

	[Required]
	[MinLength(2, ErrorMessage = "The actor's info must have at least 2 characters")]
	[MaxLength(1000, ErrorMessage = "Information about actor exceded the maximun amount of characters")]
	string Info
);


