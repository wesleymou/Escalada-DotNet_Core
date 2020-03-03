using System;
using System.Collections.Generic;

namespace Escalada.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Local { get; set; }
        public int Capacidade { get; set; }
        public int Quorum { get; set; }
        public decimal OrcamentoPrevio { get; set; } // O valor deve ser positivo.
        public decimal ValorIngresso { get; set; } // O valor deve ser positivo.
        public string Cronograma { get; set; }
        public virtual IEnumerable<Inscription> Inscricoes { get; set; }
        public virtual IEnumerable<Agreement> Fornecedores { get; set; }
        public EventStatus Status { get; set; } // Status não aceito. Status possíveis: Pronto, Em espera.
    }
}
