namespace Escalada_DotNet_Core.Models
{
    public class Subscription
    {
        private uint qtdAdulto;
        private uint qtdInfantil;
        private decimal valorTotal
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
        private decimal valorRecebido
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
        private Customer cliente;
        private Event evento;
        private string tipoPagamento
        {
            get => tipoPagamento;
            set
            {
                if (new TipoPagamento().validar(value))
                    tipoPagamento = value;
                else
                    throw new System.ArgumentException("Tipo de pagamento não aceito. Tipos de pagamentos aceitos: Crédito, Débito, Dinheiro.");
            }
        }
    }
}