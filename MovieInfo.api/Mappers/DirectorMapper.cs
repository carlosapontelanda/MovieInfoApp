using MovieInfo.api.DTOs;
using MovieInfo.api.Models;

namespace MovieInfo.api.Mappers;
public static class DirectorMapper
{
    public static DirectorDto ToDirectorDto(this Director director)
    {
        return new DirectorDto(director.Id, director.Name, director.DateOfBirth, director.Info);
    }   
}