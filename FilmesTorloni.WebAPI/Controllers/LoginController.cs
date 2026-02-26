using FilmesTorloni.WebAPI.DTO;
using FilmesTorloni.WebAPI.Interface;
using FilmesTorloni.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FilmesTorloni.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public LoginController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    public IActionResult Login(LoginDTO loginDTO)
    {
        try
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha invalida!");
            }

            //Caso encontre o usuario, prosseguir para criacao do token

            //1 - Definir as informações(Claims) que são fornecidas no token (Playload)

            var claims = new[]
            {
                //formato da claim
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario),

                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                //existe a possibilidade de criar uma claim personalizada
                //new Claim("Claim Personalizada", "Valor da claim personalizada")
            };

            //2 - Definir a chave de acesso ao token
            var key = new SymmetricSecurityKey
                (System.Text.Encoding.UTF8.GetBytes("filmes-chave-autentificacao-" +
                "webapi-dev"));

            //3 - Definir as credencias do token (HEADER)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //4 - Gerear o token
            var token = new JwtSecurityToken
            (
                //emissor do token
                issuer: "api_filmes",

                //destinatario do token
                audience: "api_filmes",

                //dados definidos nas claims(Informacoes)
                claims: claims,

                //tempo de expiracao do token
                expires: DateTime.Now.AddMinutes(5),

                //credenciais do token
                signingCredentials: creds
            );

            //5 - Retornar o token criado 
            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

   
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
