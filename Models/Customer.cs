using System.Collections.Generic;

namespace Escalada.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string NumFone1 { get; set; }
        public string NumFone2 { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<Inscription> Inscricoes { get; set; }
    }
}
