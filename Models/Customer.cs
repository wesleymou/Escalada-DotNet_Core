using System.Collections.Generic;

namespace Escalada_DotNet_Core.Models
{
    public class Customer
    {
        private uint[] cpf { get; set; } = new uint[11];
        private string nome { get; set; }
        private uint[] numFone1 { get; set; } = new uint[11];
        private uint[] numFone2 { get; set; } = new uint[11];
        private string endereco { get; set; }
        private string email { get; set; }
        private HashSet<Subscription> inscricoes = new HashSet<Subscription>();
    }
}