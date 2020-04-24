using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escalada.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "Nome completo")]
        public string Nome { get; set; }

        [Display(Name = "Telefone 1")]
        public string NumFone1 { get; set; }
        [Display(Name = "Telefone 2")]
        public string NumFone2 { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public virtual IEnumerable<Inscription> Inscricoes { get; set; }

        public bool Excluido { get; set; }
    }
}
