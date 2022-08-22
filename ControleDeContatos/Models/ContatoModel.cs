using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o email do contato!")]
        [EmailAddress(ErrorMessage = "O Email informado não é valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o telefone do contato!")]
        [Phone(ErrorMessage = "O telefone informado não é valido!")]
        public string Telefone { get; set; }
    }
}
