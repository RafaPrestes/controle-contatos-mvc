using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        // A interface do repositório é onde é criado os métodos que vai ser desenvolvido na classe de repositório
        ContatoModel BuscarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Deletar(int id);
    }
}
