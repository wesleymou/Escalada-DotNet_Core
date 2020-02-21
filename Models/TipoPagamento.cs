using System.Reflection;
namespace Escalada_DotNet_Core.Models
{
    public class TipoPagamento
    {
        private string[] tipos = { "dinheiro", "credito", "debito" };
        public bool validar(string value)
        {
            foreach (string word in tipos)
                if (word == value)
                    return true;
            return false;
        }

    }
}

// value == "Crédito" ||
//                 value == "Débito" ||
//                 value == "Dinheiro"