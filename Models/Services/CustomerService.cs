using System.Collections.Generic;
using System.Threading.Tasks;
using Escalada.Models.DataModels;

namespace Escalada.Models.Services
{
    public class CustomerService
    {
        private readonly ICustomerData _customerData;

        public CustomerService(ICustomerData customerData)
        {
            _customerData = customerData;
        }
        
        public async Task<Customer> BuscarPorId(int id) => await _customerData.BuscarPorId(id);
        public async Task<Customer> Cadastrar(Customer cliente) => await _customerData.Cadastrar(cliente);
        public async Task<List<Customer>> Listar() => await _customerData.Listar();
        public async Task Atualizar(Customer cliente) => await _customerData.Atualizar(cliente);
        public async Task Remover(int id)
        {
            Customer cliente = await _customerData.BuscarPorId(id);
            cliente.Excluido = true;
            await _customerData.Atualizar(cliente);
        }
    }
}