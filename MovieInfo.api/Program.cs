using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using MovieInfo.api.Controllers.ActionFilters;
using MovieInfo.api.Data;
using MovieInfo.api.Models;
using MovieInfo.api.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(op =>
    op.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
    op => op.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
	
builder.Services.AddIdentity<AppUser, IdentityRole>(op => {
	op.Password.RequireDigit = true;
	op.Password.RequireLowercase = true;
	op.Password.RequireUppercase = true;
	op.Password.RequireNonAlphanumeric = true;
	op.Password.RequiredLength = 12;
})
.AddEntityFrameworkStores<ApplicationDBContext>();
	
builder.Services.AddAuthentication(op => {
	op.DefaultAuthenticateScheme =
	op.DefaultChallengeScheme = 
	op.DefaultForbidScheme =
	op.DefaultScheme = 
	op.DefaultSignInScheme =
	op.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(op => {
	op.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidIssuer = builder.Configuration["JWT:Issuer"],
		ValidateAudience = true,
		ValidAudience = builder.Configuration["JWT:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(
			System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
	};
});
	
builder.Services.Configure<ApiBehaviorOptions>(op =>
	op.SuppressModelStateInvalidFilter = true);

builder.Services.AddControllers();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

