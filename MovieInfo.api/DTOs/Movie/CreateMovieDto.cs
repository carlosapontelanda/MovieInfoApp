using System.ComponentModel.DataAnnotations; 

namespace MovieInfo.api.DTOs;

public record CreateMovieDto
(
	[Required]
	[MinLength(1, ErrorMessage = "The movie title must have at least 1 character")]
	[MaxLength(50, ErrorMessage = "The movie title exceded the maximun amount of characters")]
	string Title, 
	
	[Required]
	[MinLength(1, ErrorMessage = "The synopsys must have at least 1 character")]
	[MaxLength(1000, ErrorMessage = "The synoposys exceded the maximun amount of characters")]
	string Synopsys, 
	
	[Required]
	DateOnly ReleaseYear, 
	
	[Required]
	string Genre,
	
	[Required]
    ICollection<CreateActorDto> Actors, 
	
	[Required]
	ICollection<CreateDirectorDto> Directors
);

