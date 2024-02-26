using MovieInfo.api.DTOs;
using MovieInfo.api.Models;

namespace MovieInfo.api.Mappers;
public static class ActorMapper
{
    public static ActorDto ToActorDto(this Actor actor)
    { 
        return new ActorDto(actor.Id, actor.Name, actor.DateOfBirth, actor.Info);
    }
}