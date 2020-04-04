using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escalada.Models;
using Escalada.Service;
using Escalada.Models.ViewModels;

namespace Escalada.Controllers
{
    public class EventController : Controller
    {
        private readonly EscaladaContext _context;

        public EventController(EscaladaContext context)
        {
            _context = context;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events
            .Include(e => e.Status)
            .ToListAsync());
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataInicio,DataTermino,Local,Capacidade,Quorum,OrcamentoPrevio,ValorIngresso,Cronograma,Status")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
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
            EventViewModel EventViewModel = new EventViewModel
            {
                Id = @event.Id,
                Nome = @event.Nome,
                Capacidade = @event.Capacidade,
                DataInicio = @event.DataInicio,
                DataTermino = @event.DataTermino,
                Local = @event.Local,
                OrcamentoPrevio = @event.OrcamentoPrevio,
                Quorum = @event.Quorum,
                Status = @event.Status,
                Cronograma = @event.Cronograma,
                Fornecedores = @event.Fornecedores,
                Inscricoes = @event.Inscricoes,
                ValorIngresso = @event.ValorIngresso
            };
            return View(EventViewModel);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataInicio,DataTermino,Local,Capacidade,Quorum,OrcamentoPrevio,ValorIngresso,Cronograma,StatusId")] EventViewModel EventViewModel)
        {
            if (id != EventViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Event @event = EventViewModel;
                    @event.Status = EventStatus.All.FirstOrDefault(status => status.Id == int.Parse(EventViewModel.StatusId ?? "1"));
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(EventViewModel.Id))
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
            return View(EventViewModel);
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
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
