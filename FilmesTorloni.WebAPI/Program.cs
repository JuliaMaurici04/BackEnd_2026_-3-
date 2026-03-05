using FilmesTorloni.WebAPI.BdContextFilme;
using FilmesTorloni.WebAPI.Interface;
using FilmesTorloni.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using Microsoft.OpenApi;
using System.Reflection;

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
            ValidIssuer = "api_filmes",

            //nome do audience (para onde ele esta indo)
            ValidAudience = "api_filmes"

         };
     });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Filmes API",
        Description = "Uma API com catalago de filmes",
        TermsOfService = new Uri("https://example.com./terms"),
        Contact = new OpenApiContact
        {
            Name = "JuliaMaurici04",
            Url = new Uri("https://github.com/JuliaMaurici04?tab=repositories")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT:",
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });

});

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Adiciona o serviço de Controllers
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { });

    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();


// Adiciona o mapeamento de Controllers
app.MapControllers();

app.Run();
