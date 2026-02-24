using FilmesTorloni.WebAPI.BdContextFilme;
using FilmesTorloni.WebAPI.Interface;
using FilmesTorloni.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o cintexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona o repositorio ao container  de injecao de dependencia
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();

builder.Services.AddScoped<IFilmesRepository, FilmeRepository>();
var app = builder.Build();


app.Run();
