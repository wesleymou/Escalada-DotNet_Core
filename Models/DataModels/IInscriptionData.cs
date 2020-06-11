using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escalada.Models.DataModels
{
    public interface IInscriptionData : IDataModel<Inscription>
    {
        Task<List<PaymentType>> ListarMeiosDePagamento();
    }
}