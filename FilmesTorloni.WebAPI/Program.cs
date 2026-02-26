using FilmesTorloni.WebAPI.BdContextFilme;
using FilmesTorloni.WebAPI.Interface;
using FilmesTorloni.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o cintexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona o repositorio ao container  de injecao de dependencia
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmesRepository, FilmeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Adiciona serviço de Jwt de autentificação)
builder.Services.AddAuthentication(options =>

{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
    .AddJwtBearer("JwtBearer", options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             //valida  quem esta solicitando
             ValidateIssuer = true,

             //valida  quem esta recebendo
             ValidateAudience= true,

             //define se o tempo de expiracao sera validado
             ValidateLifetime = true,

             //forma de criptografia e valida a chave de autentificacao
             IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes
             ("filmes-chave-autentificacao-webapi-dev")),

             //valida o tempo de expiracao do token
             ClockSkew = TimeSpan.FromMinutes(5),

             //nome do issuer (de onde esta vindo)
            ValidIssuer = "api-filmes",

            //nome do audience (para onde ele esta indo)
            ValidAudience = "api-filmes"

         };
     });



// Adiciona o serviço de Controllers
builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();


// Adiciona o mapeamento de Controllers
app.MapControllers();

app.Run();
