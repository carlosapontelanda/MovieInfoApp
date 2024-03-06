using MovieInfo.api.DTOs;
using MovieInfo.api.Models;

namespace MovieInfo.api.Mappers;

public static class DirectorMapper
{
    public static DirectorDto ToDirectorDto(this Director director)
    {
        return new DirectorDto(director.Id, director.Name, director.DateOfBirth, director.Info);
    }

    public static Director ToDirectorFromCreateDirectorDto(this CreateDirectorDto createDirectorDto)
    {
        return new Director
        {
            Name = createDirectorDto.Name,
            DateOfBirth = createDirectorDto.DateOfBirth,
            Info = createDirectorDto.Info
        };
    }

	public static Director ToDirectorFromUpdateDirectorDto(this UpdateDirectorDto updateDirectorDto)
    {
        return new Director
        {
			Id = updateDirectorDto.Id,
            Name = updateDirectorDto.Name,
            DateOfBirth = updateDirectorDto.DateOfBirth,
            Info = updateDirectorDto.Info
        };
    }	
}