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

    // GET: Inscription/Create
    public IActionResult Create()
    {
      return View(new InscriptionViewModel().CreateViewModel(Context: _context));
    }

    // POST: Inscription/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,QtdInteira,QtdMeia,ValorTotal,ValorRecebido,Evento,Cliente,TipoPagamento,EventId,CustomerId,PaymentTypeId")] InscriptionViewModel inscriptionViewModel)
    {
      Inscription inscription = new Inscription();
      if (ModelState.IsValid)
      {
        inscription = inscriptionViewModel.CreateModel(Context: _context);
        _context.Inscriptions.Add(inscription);
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

      var inscription = await _context.Inscriptions
        .Include(Inscription => Inscription.Cliente)
        .Include(Inscription => Inscription.Evento)
        .Include(Inscription => Inscription.TipoPagamento)
        .FirstAsync(m => id == m.Id);

      if (inscription == null)
      {
        return NotFound();
      }

      return View(new InscriptionViewModel().CreateViewModel(Context: _context, Inscription: inscription));
    }

    // POST: Inscription/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,QtdInteira,QtdMeia,ValorTotal,ValorRecebido,Evento,Cliente,TipoPagamento,EventId,CustomerId,PaymentTypeId")] InscriptionViewModel inscriptionViewModel)
    {
      if (id != inscriptionViewModel.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(inscriptionViewModel.CreateModel(Context: _context));
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!InscriptionExists(inscriptionViewModel.Id))
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
      return View(inscriptionViewModel);
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
      _context.Inscriptions.Remove(inscription);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool InscriptionExists(int id)
    {
      return _context.Inscriptions.Any(e => e.Id == id);
    }
  }
}