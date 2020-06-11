using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escalada.Models;
using Escalada.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Escalada.Persistence.DataModels
{
    public class EscaladaEventData : IEventData
    {
        private readonly EscaladaContext _context;

        public EscaladaEventData(EscaladaContext context)
        {
            _context = context;
        }

        public async Task<Event> BuscarPorId(int id)
        {
            return await _context.Events
                .Include(e => e.Status)
                .Include(e => e.Inscricoes)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Event>> Listar()
        {
            return await _context.Events
                .Include(e => e.Inscricoes)
                .Include(e => e.Fornecedores)
                .Include(e => e.Status)
                .ToListAsync();
        }

        public async Task<Event> Cadastrar(Event evento)
        {
            _context.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task Atualizar(Event obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var evento = await _context.Events.FindAsync(id);
            _context.Remove(evento);
        }

        public async Task<List<EventStatus>> ListarStatusEvento()
        {
            return await _context.EventStatus.ToListAsync();
        }
    }
}