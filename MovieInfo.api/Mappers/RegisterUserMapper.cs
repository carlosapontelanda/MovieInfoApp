using MovieInfo.api.DTOs;
using MovieInfo.api.Models;

namespace MovieInfo.api.Mappers;

public static class RegisterMapper
{
    public static AppUser ToAppUserFromRegisterDto(this RegisterDto registerDto)
    { 
        return new AppUser
		{
			UserName = registerDto.UserName,
			Email = registerDto.Email
		};
    }

}