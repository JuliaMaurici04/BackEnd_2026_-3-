using EventPlusTorloni.WebAPI.BdContextFilme;
using EventPlusTorloni.WebAPI.Interfaces;
using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Repositories;

public class TipoEventoRepository : ITipoEventoRepository
{
    private readonly EventContext _context;

    // Injecao de dependencia: Recebe o contexto pelo computador

    public TipoEventoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de evento usando o rastreamento automatico
    /// </summary>
    /// <param name="id">id do evento a ser atualizado</param>
    /// <param name="tipoEvento">Novos dados do tipo evento</param>
    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);
    }

    /// <summary>
    /// Cadastrar um novo tipo de evento 
    /// </summary>
    /// <param name="id">id do evento a ser atualizado</param>
    /// <param name="tipoEvento">tipo de evento a ser cadastrado</param>
    public TipoEvento BuscarPorId(Guid id)
    {
        return _context.TipoEventos.Find();
    }

    /// <summary>
    /// Cadastrar um novo tipo de evento 
    /// </summary>
    /// <param name="id">id do evento a ser atualizado</param>
    /// <param name="tipoEvento">tipo de evento a ser cadastrado</param>

    public void Cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges(); 
    }

    /// <summary>
    /// Deletar um novo tipo de evento 
    /// </summary>
    /// <param name="id">id do evento a ser atualizado</param>
    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if (tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Buscar a lista de tipo de eventos cadastrados
    /// </summary>
    /// <returns>Uma Lista de tipo eventos</returns>
    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(TipoEvento => TipoEvento.Titulo).ToList();
    }
}
