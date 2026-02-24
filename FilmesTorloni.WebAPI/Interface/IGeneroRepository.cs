using FilmesTorloni.WebAPI.Models;

namespace FilmesTorloni.WebAPI.Interface
{
    public interface IGeneroRepository
    {
        void Cadastrar(Genero novoGenero);
        void AtualizarIdCorpo(Genero generoAtualizado);
        void AtualizarIdUrl(Guid id, Genero generoAtualizado);
        List<Genero> Listar();
        void Deletar(Guid id);
        Genero buscarPorId(Guid id);
    }
}
