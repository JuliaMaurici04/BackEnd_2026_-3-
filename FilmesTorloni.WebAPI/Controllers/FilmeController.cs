using FilmesTorloni.WebAPI.Interface;
using FilmesTorloni.WebAPI.Models;
using FilmesTorloni.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesTorloni.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmeController : ControllerBase
{
    private readonly IFilmesRepository _filmeRepository;

    public FilmeController(IFilmesRepository filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_filmeRepository.BuscarPorId(id));
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }


    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_filmeRepository.Listar());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Post(Filme novoFilme)
    {
        try
        {
            _filmeRepository.Cadastrar(novoFilme);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, Filme filmeAtualizado)
    {
        try
        {
            _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);
            return NoContent();
        }
        catch (Exception e)
        {

            return  BadRequest(e.Message);
        }
    }

    [HttpPut]
    public IActionResult PutBody(Filme filmeAtualizado)
    {
        try
        {
            _filmeRepository.AtualizarIdCorpo(filmeAtualizado);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _filmeRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
