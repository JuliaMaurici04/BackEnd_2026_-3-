using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interfaces;

public interface IPresencaRepository
{
    void Inscrever(IPresencaRepository inscricao);
    void Deletar(Guid id);
    List<Presenca> Listar();
    Presenca BuscarPorId(Guid id);
    void Atualizar(Guid id);
    List<Presenca> ListarMinhas(Guid IdUsuario);
}
