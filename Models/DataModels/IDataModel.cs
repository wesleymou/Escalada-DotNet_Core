using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escalada.Models.DataModels
{
    public interface IDataModel<T>
    {
        Task<T> BuscarPorId(int id);
        Task<List<T>> Listar();
        Task<T> Cadastrar(T obj);
        Task Atualizar(T obj);
        Task Remover(int id);
    }
}