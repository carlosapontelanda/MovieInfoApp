namespace MovieInfo.api.DTOs;
public record MovieDto(int Id, string Title, string Synopsys, int ReleaseYear, string Genre, List<ActorDto> Actors,
        List<DirectorDto> Directors);