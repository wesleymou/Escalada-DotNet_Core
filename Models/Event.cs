using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Escalada.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Display(Name = "Nome do evento")]
        public string Nome { get; set; }

        [Display(Name = "Início do evento")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Fim do evento")]
        public DateTime DataTermino { get; set; }

        public string Local { get; set; }
        public int Capacidade { get; set; }

        [Display(Name = "Quantidade mínima de ingressos (quorum)")]
        public int Quorum { get; set; }

        [Display(Name = "Orçamento prévio")]
        public decimal OrcamentoPrevio { get; set; }

        [Display(Name = "Valor do ingresso")]
        public decimal ValorIngresso { get; set; }

        public string Cronograma { get; set; }
        public IEnumerable<Inscription> Inscricoes { get; set; }
        public IEnumerable<Agreement> Fornecedores { get; set; }

        [Display(Name = "Status do evento")]
        public EventStatus Status { get; set; }
        public bool Excluido { get; set; }
        
        public int QtdDisponiveis { get => Capacidade - Inscricoes?.Count() ?? 0; }
    }
}
