using System.Collections.Generic;

namespace Escalada.Models
{
    public class Customer
    {

        public Customer(uint[] cpf, string nome, uint[] numFone1, uint[] numFone2, string endereco, string email)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.numFone1 = numFone1;
            this.numFone2 = numFone2;
            this.endereco = endereco;
            this.email = email;
        }
        public int id { get; set; }
        public uint[] cpf { get; set; } = new uint[11];
        public string nome { get; set; }
        public uint[] numFone1 { get; set; } = new uint[11];
        public uint[] numFone2 { get; set; } = new uint[11];
        public string endereco { get; set; }
        public string email { get; set; }
        public ICollection<Inscription> inscricoes { get; set; }
    }
}