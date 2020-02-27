namespace Escalada_DotNet_Core.Models
{
    public class SubscriptionInEvents
    {
        public int id { get; set; }
        public uint qtdAdulto;
        public uint qtdInfantil;
        public decimal valorTotal
        {
            get => valorTotal;
            set
            {
                if (value > 0)
                    valorTotal = value;
                else
                    throw new System.ArgumentException("O valor deve ser positivo.");
            }
        }
        public decimal valorRecebido
        {
            get => valorRecebido;
            set
            {
                if (value > 0)
                    valorRecebido = value;
                else
                    throw new System.ArgumentException("O valor deve ser positivo.");
            }
        }
        public Customer clienteId;
        public Event eventoId;
        public PaymentType tipoPagamentoId { get; set; }
    }
}