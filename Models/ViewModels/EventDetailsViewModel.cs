using System;
using System.Collections.Generic;
using System.Linq;

namespace Escalada.Models.ViewModels
{
    public class EventDetailsViewModel
    {
        public Event Evento { get; set; }
        public decimal ValorArrecadado { get => Evento.Inscricoes.Sum(i => i.ValorRecebido); }
        public int IngressosVendidos { get => Evento.Inscricoes.Sum(i => i.QtdInteira + i.QtdMeia); }
        public int IngressosRestantes { get => Evento.Capacidade - IngressosVendidos; }
        public double PorcentagemVendidos { get => Math.Ceiling((double)(IngressosVendidos * 100) / Evento.Capacidade); }
    }
}