using Microsoft.EntityFrameworkCore;
using MovieInfo.api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(op =>
    op.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
    op => op.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

builder.Services.AddControllers();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

