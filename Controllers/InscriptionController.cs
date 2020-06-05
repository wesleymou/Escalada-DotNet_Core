using System.Collections.Generic;
using System.Threading.Tasks;
using Escalada.Models;
using Escalada.Models.Services;
using Escalada.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Escalada.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class InscriptionController : Controller
    {
        private readonly InscriptionService _inscriptionService;
        private readonly EventService _eventService;
        private readonly CustomerService _customerService;

        public InscriptionController(
            CustomerService customerService,
            EventService eventService,
            InscriptionService inscriptionService)
        {
            _customerService = customerService;
            _eventService = eventService;
            _inscriptionService = inscriptionService;
        }

        // GET: Inscription
        public async Task<IActionResult> Index()
        {
            return View(await _inscriptionService.Listar());
        }

        // GET: Inscription/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscription = await _inscriptionService.BuscarPorId(id.Value);

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
            [Bind("QtdInteira,QtdMeia,ValorTotal,ValorRecebido,EventoId,ClienteId,TipoPagamentoId")] Inscription inscription)
        {
            if (ModelState.IsValid)
            {
                await _inscriptionService.Cadastrar(inscription);
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

            var inscription = await _inscriptionService.BuscarPorId(id.Value);

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
            [Bind("Id,QtdInteira,QtdMeia,ValorTotal,ValorRecebido,EventoId,ClienteId,TipoPagamentoId")] Inscription inscription)
        {
            if (id != inscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _inscriptionService.Atualizar(inscription);
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

            var inscription = await _inscriptionService.BuscarPorId(id.Value);

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
            await _inscriptionService.Remover(id);
            return RedirectToAction(nameof(Index));
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

        private async Task<IEnumerable<Customer>> GetCustomers() => await _customerService.Listar();
        private async Task<IEnumerable<Event>> GetEvents() => await _eventService.Listar();

        private async Task<IEnumerable<PaymentType>> GetPaymentTypes() =>
            await _inscriptionService.ListarMeiosDePagamento();
    }
}