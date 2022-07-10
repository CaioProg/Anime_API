using Microsoft.EntityFrameworkCore;
using Animes.Data;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

string AnimeConnection = builder.Configuration.GetConnectionString("AnimeConnection");

builder.Services.AddDbContextPool<AnimeContext>(options =>
                options.UseMySql(AnimeConnection,
                      ServerVersion.AutoDetect(AnimeConnection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

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
