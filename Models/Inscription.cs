using System.ComponentModel.DataAnnotations;

namespace Escalada.Models
{
  public class Inscription
  {
    [Display(Name = "Código do pedido")]
    public int Id { get; set; }
    
    [Display(Name = "Quantidade inteira")]
    public int QtdInteira { get; set; }
    
    [Display(Name = "Quantidade meia")]
    public int QtdMeia { get; set; }
    
    [Display(Name = "Valor total")]
    public decimal ValorTotal { get;  set; }
    
    [Display(Name = "Valor pago")]
    public decimal ValorRecebido { get; set; }
    
    [Display(Name = "Valor devido")]
    public decimal ValorDevido
    {
      get => ValorTotal - ValorRecebido;
    }
    
    public Customer Cliente { get; set; }
    
    public Event Evento { get; set; }
    
    [Display(Name = "Meio de Pagamento")]
    public PaymentType TipoPagamento { get; set; }

    public int? TipoPagamentoId { get; set; }
    public int? EventoId { get; set; }
    public int? ClienteId { get; set; }
  }
}
