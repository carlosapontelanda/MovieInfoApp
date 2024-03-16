using MovieInfo.api.Models;

namespace MovieInfo.api.Services;

public interface ITokenService
{
	string CreateToken(AppUser appUser);
}
