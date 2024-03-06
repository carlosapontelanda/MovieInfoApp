using MovieInfo.api.DTOs;
using MovieInfo.api.Models;

namespace MovieInfo.api.Mappers;

public static class ActorMapper
{
    public static ActorDto ToActorDto(this Actor actor)
    { 
        return new ActorDto(actor.Id, actor.Name, actor.DateOfBirth, actor.Info);
    }

    public static Actor ToActorFromCreateActorDto(this CreateActorDto createActorDto)
    {
        return new Actor
        {
            Name = createActorDto.Name,
            DateOfBirth = createActorDto.DateOfBirth,
            Info = createActorDto.Info
        };
    }
	
	public static Actor ToActorFromUpdateActorDto(this UpdateActorDto updateActorDto)
    {
        return new Actor
        {
			Id = updateActorDto.Id,
            Name = updateActorDto.Name,
            DateOfBirth = updateActorDto.DateOfBirth,
            Info = updateActorDto.Info
        };
    }
}