using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escalada.Models;
using Escalada.Models.ViewModels;
using Escalada.Persistence;

namespace Escalada.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class EventController : Controller
    {
        private readonly EscaladaContext _context;

        public EventController(EscaladaContext context)
        {
            _context = context;
        }

        // GET: Event
        public async Task<IActionResult> Index(bool excluidos)
        {
            var events = await _context.Events
                .Where(e => excluidos || e.Excluido == false)
                .Include(e => e.Status)
                .ToListAsync();

            return View(events);
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Status)
                .Include(e => e.Inscricoes)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public async Task<IActionResult> Create()
        {
            List<EventStatus> statuses = await GetEventStatuses();
            EventEditViewModel model = EventViewModelFactory.CreateEditViewModel(null, statuses);
            return View(model);
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Nome,DataInicio,DataTermino,Local,Capacidade,Quorum,OrcamentoPrevio,ValorIngresso,Cronograma,StatusId")]
            EventEditViewModel form)
        {
            var @event = (Event) form;

            @event.Status = await _context.EventStatus.FindAsync(form.StatusId);

            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<EventStatus> statuses = await GetEventStatuses();
            EventEditViewModel model = EventViewModelFactory.CreateEditViewModel(@event, statuses);

            return View(model);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Status)
                .FirstAsync(m => id == m.Id);

            if (@event == null)
            {
                return NotFound();
            }

            List<EventStatus> statuses = await GetEventStatuses();
            EventEditViewModel model = EventViewModelFactory.CreateEditViewModel(@event, statuses);

            return View(model);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "Id,Nome,DataInicio,DataTermino,Local,Capacidade,Quorum,OrcamentoPrevio,ValorIngresso,Cronograma,StatusId")]
            EventEditViewModel form)
        {
            var @event = (Event) form;

            if (id != form.Id)
            {
                return NotFound();
            }

            @event.Status = await _context.EventStatus.FindAsync(form.StatusId);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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

            List<EventStatus> statuses = await GetEventStatuses();
            EventEditViewModel model = EventViewModelFactory.CreateEditViewModel(@event, statuses);

            return View(model);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Status)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events
                .FindAsync(id);

            @event.Excluido = true;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }

        private async Task<List<EventStatus>> GetEventStatuses() => await _context.EventStatus.ToListAsync();
    }
}