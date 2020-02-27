using System;
using System.Collections.Generic;

namespace Escalada_DotNet_Core.Models
{
    public class Event
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public string local { get; set; }
        public uint capacidade { get; set; }
        public uint quorum { get; set; }
        public decimal orcamentoPrevio
        {
            get => orcamentoPrevio;
            set
            {
                if (value > 0)
                    orcamentoPrevio = value;
                else
                    throw new System.ArgumentException("O valor deve ser positivo.");
            }
        }
        public decimal valorIngresso
        {
            get => valorIngresso;
            set
            {
                if (value > 0)
                    valorIngresso = value;
                else
                    throw new System.ArgumentException("O valor deve ser positivo.");
            }
        }
        public SortedDictionary<DateTime, string> cronograma = new SortedDictionary<DateTime, string>();
        //	public int convenio[];
        public ICollection<SubscriptionInEvents> clientes { get; set; }
        public ICollection<SubscriptionProvider> fornecedores { get; set; }
        public string status
        {
            get => status;
            set
            {
                if (value == "Pronto" ||
                    value == "Em espera")
                    status = value;
                else
                    throw new System.ArgumentException("Status não aceito. Status possíveis: Pronto, Em espera.");
            }
        }
    }
}