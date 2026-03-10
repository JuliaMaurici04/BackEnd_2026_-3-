using EventPlusTorloni.WebAPI.BdContextFilme;
using EventPlusTorloni.WebAPI.Interfaces;
using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{
    private readonly EventContext _context;

    public InstituicaoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de instituicao usando o rastreamento automatico
    /// </summary>
    /// <param name="id">id do evento a ser atualizado</param>
    /// <param name="instituicao">Novos dados do tipoInstituicao</param>
    public void Atualizar(Guid id, Instituicao instituicao)
    {
        var InstituicaoBuscada = _context.Instituicaos.Find(id);

        if (InstituicaoBuscada != null)
        {
            InstituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
            InstituicaoBuscada.Cnpj = instituicao.Cnpj;
            InstituicaoBuscada.Endereco = instituicao.Endereco;

            //O SaveChanges() detecta a mudança na propriedade "Título" automaticamente
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Buscar um novo tipo de instituicao
    /// </summary>
    /// <param name="id">id do evento a ser atualizado</param>
    /// <param name="instituicao">tipo de instituicao a ser cadastrado</param>
    public Instituicao BuscarPorId(Guid id)
    {
        return _context.Instituicaos.Find(id)!;
    }

    /// <summary>
    /// Cadastrar um novo tipo de instituicao
    /// </summary>
    /// <param name="id">id da instituicao a ser atualizado</param>
    /// <param name="tipoInstituicao">tipo de instituicao a ser cadastrado</param>
    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);
        _context.SaveChanges();
    }
    


    /// <summary>
    /// Deletar um novo tipo de evento 
    /// </summary>
    /// <param name="id">id de instituicao ser atualizado</param>
    /// <param name="tipoInstituicao">tipo de inatituicao deletado</param>
    public void Deletar(Guid id)
    {
        var InstituicaoBuscada = _context.Instituicaos.Find(id);

        if (InstituicaoBuscada != null)
        {
            _context.Instituicaos.Remove(InstituicaoBuscada);
            _context.SaveChanges();
        }

    }

    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.OrderBy(Instituicao => Instituicao.NomeFantasia).ToList();
    }
}
