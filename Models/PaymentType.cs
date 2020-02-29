using Escalada.Utils;

namespace Escalada.Models
{
    public class PaymentType
    {
        public int id { get; set; }
        public string type
        {
            get => type;
            set
            {
                value = value.RemoveAccents().ToUpper();
                if (value == "pronto" ||
                    value == "debito" ||
                    value == "credito")
                    type = value;
                else
                    throw new System.ArgumentException("Tipo de pagamento não aceito. Tipos de pagamentos aceitos: Crédito, Débito, Dinheiro.");
            }
        }
        public bool validar(string value)
        {
            //TODO: função bool para validar tipo de pagamento
            return false;
        }

    }
}

// value == "Crédito" ||
//                 value == "Débito" ||
//                 value == "Dinheiro"