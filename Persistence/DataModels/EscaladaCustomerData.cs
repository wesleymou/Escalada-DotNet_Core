using System.Collections.Generic;
using System.Threading.Tasks;
using Escalada.Models;
using Escalada.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Escalada.Persistence.DataModels
{
    public class EscaladaCustomerData : ICustomerData
    {
        private readonly EscaladaContext _context;

        public EscaladaCustomerData(EscaladaContext context)
        {
            _context = context;
        }

        public async Task<Customer> BuscarPorId(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            return customer;
        }

        public async Task<List<Customer>> Listar()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> Cadastrar(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task Atualizar(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}