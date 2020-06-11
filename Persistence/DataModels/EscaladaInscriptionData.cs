using System.Collections.Generic;
using System.Threading.Tasks;
using Escalada.Models;
using Escalada.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Escalada.Persistence.DataModels
{
    public class EscaladaInscriptionData : IInscriptionData
    {
        private readonly EscaladaContext _context;

        public EscaladaInscriptionData(EscaladaContext context)
        {
            _context = context;
        }

        public async Task<Inscription> BuscarPorId(int id)
        {
            return await _context.Inscriptions
                .Include(i => i.Cliente)
                .Include(i => i.Evento)
                .Include(i => i.TipoPagamento)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Inscription>> Listar()
        {
            return await _context.Inscriptions
                .Include(i => i.Cliente)
                .Include(i => i.Evento)
                .Include(i => i.TipoPagamento)
                .ToListAsync();
        }

        public async Task<Inscription> Cadastrar(Inscription inscription)
        {
            _context.Add(inscription);
            await _context.SaveChangesAsync();
            return inscription;
        }

        public async Task Atualizar(Inscription inscription)
        {
            _context.Update(inscription);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var inscription = await _context.Inscriptions.FindAsync(id);
            _context.Remove(inscription);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PaymentType>> ListarMeiosDePagamento()
        {
            return await _context.PaymentTypes.ToListAsync();
        }
    }
}