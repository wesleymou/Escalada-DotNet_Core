namespace Escalada.Models
{
  public class Inscription
  {
    public int Id { get; set; }
    public int QtdInteira { get; set; }
    public int QtdMeia { get; set; }
    public decimal ValorTotal { get; set; } // O valor deve ser positivo.
    public decimal ValorRecebido { get; set; } // O valor deve ser positivo.
    public Customer Cliente { get; set; }
    public Event Evento { get; set; }
    public PaymentType TipoPagamento { get; set; }
  }
}
