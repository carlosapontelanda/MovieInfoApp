using MovieInfo.api.DTOs;

namespace MovieInfo.api;
public static class DirectorMapper
{
    public static DirectorDto ToDirectorDto(this Director director)
    {
        return new DirectorDto(director.Id, director.Name, director.DateOfBirth, director.Info);
    }   
}