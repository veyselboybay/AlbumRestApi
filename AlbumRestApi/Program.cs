using AlbumRestApi;
using AlbumRestApi.Repositories;
using AlbumRestApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGenreRepository,GenreRepository>();
builder.Services.AddScoped<IMovieRepository,MovieRepository>();
builder.Services.AddScoped<IGenreService,GenreService>();
builder.Services.AddScoped<IMovieService,MovieService>();
builder.Services.AddScoped<IFileUploadService,S3UploadService>();


// Connection String
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
if(connectionString == null)
{
    connectionString = builder.Configuration.GetConnectionString("albumapi");
}
// Add services to the container.
// Database Service
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
