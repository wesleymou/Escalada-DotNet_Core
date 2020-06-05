using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escalada.Models.DataModels
{
    public interface IEventData : IDataModel<Event>
    {
        Task<List<EventStatus>> ListarStatusEvento();
    }
}