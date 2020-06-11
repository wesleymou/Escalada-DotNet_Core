using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Escalada.Models;
using Escalada.Models.Services;
using Escalada.Models.ViewModels;

namespace Escalada.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        // GET: Event
        public async Task<IActionResult> Index(bool excluidos)
        {
            var events = await _eventService.Listar();
            return View(events);
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _eventService.BuscarPorId(id.Value);

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
            
            List<EventStatus> statuses = await GetEventStatuses();

            @event.Status = statuses.FirstOrDefault(s => s.Id == form.StatusId);

            if (ModelState.IsValid)
            {
                await _eventService.Cadastrar(@event);
                return RedirectToAction(nameof(Index));
            }

            EventEditViewModel model = EventViewModelFactory
                .CreateEditViewModel(@event, statuses);

            return View(model);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _eventService.BuscarPorId(id.Value);

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
            
            List<EventStatus> statuses = await GetEventStatuses();

            if (id != form.Id)
            {
                return NotFound();
            }

            @event.Status = statuses.FirstOrDefault(s => s.Id == form.StatusId);

            if (ModelState.IsValid)
            {
                await _eventService.Atualizar(@event);
                return RedirectToAction(nameof(Index));
            }

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

            var @event = await _eventService.BuscarPorId(id.Value);

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
            await _eventService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<List<EventStatus>> GetEventStatuses() => await _eventService.ListarStatusEvento();
    }
}