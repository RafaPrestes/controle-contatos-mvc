using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio // herda a interface 
    {
        private readonly BancoContext _bancoContext; // cria um readonly para acessar os dados do banco (BancoContext)

        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public ContatoModel BuscarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {  
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            // gravar no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorId(contato.Id);
            if (contatoDB == null)
            {
                throw new System.Exception("Houve um erro na atualização do contato!");
            }
            contatoDB.Name = contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.Telefone = contato.Telefone;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Deletar(int id)
        {
            ContatoModel contatoDB = BuscarPorId(id);
            if (contatoDB == null)
            {
                throw new System.Exception("Houve um erro na deleção do contato!");
            }

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
