using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Escalada.Models;
using Escalada.Models.Services;
using Escalada.Models.ViewModels;

namespace Escalada.Controllers
{
  [Microsoft.AspNetCore.Authorization.Authorize]
  public class CustomerController : Controller
  {
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
      _customerService = customerService;
    }
    
    // GET: Customer
    public async Task<IActionResult> Index()
    {
      var customers = (await _customerService.Listar()).ToList();

      var model = new CustomerListViewModel
      {
        Customers = customers,
        ShowDeleted = false
      };

      return View(model);
    }

    // GET: Customer/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var customer = await _customerService.BuscarPorId(id.Value);

      if (customer == null)
      {
        return NotFound();
      }

      return View(customer);
    }

    // GET: Customer/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Customer/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Cpf,Nome,NumFone1,NumFone2,Endereco,Email")] Customer customer)
    {
      if (ModelState.IsValid)
      {
        await _customerService.Cadastrar(customer);
        return RedirectToAction(nameof(Index));
      }
      return View(customer);
    }

    // GET: Customer/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var customer = await _customerService.BuscarPorId(id.Value);
      if (customer == null)
      {
        return NotFound();
      }
      return View(customer);
    }

    // POST: Customer/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Cpf,Nome,NumFone1,NumFone2,Endereco,Email")] Customer customer)
    {
      if (id != customer.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        await _customerService.Atualizar(customer);
        return RedirectToAction(nameof(Index));
      }
      return View(customer);
    }

    // GET: Customer/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var customer = await _customerService.BuscarPorId(id.Value);
      if (customer == null)
      {
        return NotFound();
      }

      return View(customer);
    }

    // POST: Customer/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await _customerService.Remover(id);
      return RedirectToAction(nameof(Index));
    }
  }
}
