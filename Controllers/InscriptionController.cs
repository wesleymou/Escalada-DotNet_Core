using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escalada.Models;
using Escalada.Models.ViewModels;
using Escalada.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Escalada.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class InscriptionController : Controller
    {
        private readonly EscaladaContext _context;

        public InscriptionController(EscaladaContext context)
        {
            _context = context;
        }

        // GET: Inscription
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inscriptions
                .Include(i => i.Cliente)
                .Include(i => i.Evento)
                .Include(i => i.TipoPagamento)
                .ToListAsync());
        }

        // GET: Inscription/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions
                .Include(i => i.Cliente)
                .Include(i => i.Evento)
                .Include(i => i.TipoPagamento)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (inscription == null)
            {
                return NotFound();
            }

            return View(inscription);
        }

        // GET: Inscription/Create
        public async Task<IActionResult> Create()
        {
            var model = await BuildEditViewModel(null);
            return View(model);
        }

        // POST: Inscription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Id,QtdInteira,QtdMeia,ValorTotal,ValorRecebido,Evento,Cliente,TipoPagamento,EventId,CustomerId,PaymentTypeId")]
            InscriptionEditViewModel form)
        {
            var inscription = (Inscription) form;

            inscription.Cliente = await _context.Customers.FindAsync(form.CustomerId);
            inscription.Evento = await _context.Events.FindAsync(form.EventId);
            inscription.TipoPagamento = await _context.PaymentTypes.FindAsync(form.PaymentTypeId);

            if (ModelState.IsValid)
            {
                _context.Add(inscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var model = await BuildEditViewModel(inscription);
            return View(model);
        }

        // GET: Inscription/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions
                .Include(Inscription => Inscription.Cliente)
                .Include(Inscription => Inscription.Evento)
                .Include(Inscription => Inscription.TipoPagamento)
                .FirstAsync(m => id == m.Id);

            if (inscription == null)
            {
                return NotFound();
            }

            var model = await BuildEditViewModel(inscription);
            return View(model);
        }

        // POST: Inscription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "Id,QtdInteira,QtdMeia,ValorTotal,ValorRecebido,Evento,Cliente,TipoPagamento,EventId,CustomerId,PaymentTypeId")]
            InscriptionEditViewModel form)
        {
            var inscription = (Inscription) form;

            if (id != inscription.Id)
            {
                return NotFound();
            }

            inscription.Cliente = await _context.Customers.FindAsync(form.CustomerId);
            inscription.Evento = await _context.Events.FindAsync(form.EventId);
            inscription.TipoPagamento = await _context.PaymentTypes.FindAsync(form.PaymentTypeId);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscriptionExists(inscription.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            var model = await BuildEditViewModel(inscription);
            return View(model);
        }

        // GET: Inscription/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions
                .Include(Inscription => Inscription.Cliente)
                .Include(Inscription => Inscription.Evento)
                .Include(Inscription => Inscription.TipoPagamento)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (inscription == null)
            {
                return NotFound();
            }

            return View(inscription);
        }

        // POST: Inscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscription = await _context.Inscriptions.FindAsync(id);
            _context.Remove(inscription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscriptionExists(int id)
        {
            return _context.Inscriptions.Any(e => e.Id == id);
        }

        private async Task<InscriptionEditViewModel> BuildEditViewModel(Inscription inscription)
        {
            InscriptionEditViewModel model = InscriptionViewModelFactory.CreateEditViewModel(
                inscription,
                events: await GetEvents(),
                paymentTypes: await GetPaymentTypes(),
                customers: await GetCustomers()
            );

            return model;
        }

        private async Task<IEnumerable<Customer>> GetCustomers() => await _context.Customers.ToListAsync();
        private async Task<IEnumerable<Event>> GetEvents() => await _context.Events.ToListAsync();
        private async Task<IEnumerable<PaymentType>> GetPaymentTypes() => await _context.PaymentTypes.ToListAsync();
    }
}