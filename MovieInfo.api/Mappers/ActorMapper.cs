using MovieInfo.api.DTOs;

namespace MovieInfo.api;
public static class ActorMapper
{
    public static ActorDto ToActorDto(this Actor actor)
    { 
        return new ActorDto(actor.Id, actor.Name, actor.DateOfBirth, actor.Info);
    }
}