using System;
using System.Collections.Generic;

namespace Escalada_DotNet_Core.Models
{
    public class Event
    {
        private string nome { get; set; }
        private DateTime dataInicio { get; set; }
        private DateTime dataTermino { get; set; }
        private string local { get; set; }
        private uint capacidade { get; set; }
        private uint quorum { get; set; }
        private decimal orcamentoPrevio
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
        private decimal valorIngresso
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
        private SortedDictionary<DateTime, string> cronograma = new SortedDictionary<DateTime, string>();
        //	private int convenio[];
        private HashSet<Subscription> inscricoes = new HashSet<Subscription>();
        private string status
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