using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escalada.Models;
using Escalada.Models.ViewModels;
using Escalada.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Escalada
{
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
      return View(await _context.Inscription
        .Include(Inscription => Inscription.Cliente)
        .Include(Inscription => Inscription.Evento)
        .Include(Inscription => Inscription.TipoPagamento)
        .ToListAsync());
    }

    // GET: Inscription/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var inscription = await _context.Inscription
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

    // GET: Inscription/Create
    public IActionResult Create()
    {
      InscriptionViewModel inscriptionViewModel = new InscriptionViewModel
      {
        Events = _context.Events.ToList().Select(Event =>
      new SelectListItem
      {
        Value = Event.Id.ToString(),
        Text = Event.Nome
      }),
        Customers = _context.Customers.ToList().Select(Customer =>
      new SelectListItem
      {
        Value = Customer.Id.ToString(),
        Text = Customer.Nome
      }),
        PaymentTypes = _context.PaymentTypes.ToList().Select(PaymentType =>
      new SelectListItem
      {
        Value = PaymentType.Id.ToString(),
        Text = PaymentType.Description
      })
      };

      return View(inscriptionViewModel);
    }

    // POST: Inscription/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,QtdAdulto,QtdInfantil,ValorTotal,ValorRecebido,Evento,Cliente,TipoPagamento,EventId,CustomerId,PaymentTypeId")] InscriptionViewModel inscriptionViewModel)
    {
      Inscription inscription = inscriptionViewModel;
      if (ModelState.IsValid)
      {
        inscription.Cliente = _context.Customers.FirstOrDefault(c => c.Id == int.Parse(inscriptionViewModel.CustomerId ?? "1"));
        inscription.Evento = _context.Events.FirstOrDefault(e => e.Id == int.Parse(inscriptionViewModel.EventId ?? "1"));
        inscription.TipoPagamento = _context.PaymentTypes.FirstOrDefault(p => p.Id == int.Parse(inscriptionViewModel.PaymentTypeId ?? "1"));

        _context.Inscription.Add(inscription);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(inscription);
    }

    // GET: Inscription/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var inscription = await _context.Inscription.FindAsync(id);
      InscriptionViewModel inscriptionViewModel = new InscriptionViewModel
      {
        Id = inscription.Id,
        QtdAdulto = inscription.QtdAdulto,
        QtdInfantil = inscription.QtdInfantil,
        ValorTotal = inscription.ValorTotal,
        ValorRecebido = inscription.ValorRecebido,
        Cliente = inscription.Cliente,
        Evento = inscription.Evento,
        TipoPagamento = inscription.TipoPagamento,
        Events = _context.Events.ToList().Select(Event =>
          new SelectListItem
          {
            Value = Event.Id.ToString(),
            Text = Event.Nome
          }),
        Customers = _context.Customers.ToList().Select(Customer =>
        new SelectListItem
        {
          Value = Customer.Id.ToString(),
          Text = Customer.Nome
        }),
        PaymentTypes = _context.PaymentTypes.ToList().Select(PaymentType =>
        new SelectListItem
        {
          Value = PaymentType.Id.ToString(),
          Text = PaymentType.Description
        })
      };

      if (inscriptionViewModel == null)
      {
        return NotFound();
      }
      return View(inscriptionViewModel);
    }

    // POST: Inscription/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,QtdAdulto,QtdInfantil,ValorTotal,ValorRecebido,Evento,Cliente,TipoPagamento,EventId,CustomerId,PaymentTypeId")] InscriptionViewModel inscription)
    {
      if (id != inscription.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        inscription.Cliente = _context.Customers.FirstOrDefault(c => c.Id == int.Parse(inscription.CustomerId ?? "1"));
        inscription.Evento = _context.Events.FirstOrDefault(e => e.Id == int.Parse(inscription.EventId ?? "1"));
        inscription.TipoPagamento = _context.PaymentTypes.FirstOrDefault(p => p.Id == int.Parse(inscription.PaymentTypeId ?? "1"));
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
      return View(inscription);
    }

    // GET: Inscription/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var inscription = await _context.Inscription
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
      var inscription = await _context.Inscription.FindAsync(id);
      _context.Inscription.Remove(inscription);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool InscriptionExists(int id)
    {
      return _context.Inscription.Any(e => e.Id == id);
    }
  }
}