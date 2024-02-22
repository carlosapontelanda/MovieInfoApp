namespace MovieInfo.api.Mappers;

public class DirectorMapper
{
    public static DirectorDto ToDirectorDto(this Director director)
    {
        return new DirectorDto() { director.Id, director.Name, director.DateOfBirth, director.Info };
    }
    
}

