using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escalada.Service;
using AutoMapper;

namespace Escalada.Models.ViewModels
{
  public class InscriptionViewModel : Inscription
  {
    public Inscription CreateModel(EscaladaContext Context)
    {
      this.Cliente = Context.Customers.FirstOrDefault(c => c.Id == int.Parse(this.CustomerId ?? "1"));
      this.Evento = Context.Events.FirstOrDefault(e => e.Id == int.Parse(this.EventId ?? "1"));
      this.TipoPagamento = Context.PaymentTypes.FirstOrDefault(p => p.Id == int.Parse(this.PaymentTypeId ?? "1"));
      return this;
    }
    public InscriptionViewModel CreateViewModel(EscaladaContext Context, Inscription Inscription)
    {
      var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Inscription, InscriptionViewModel>()));

      InscriptionViewModel InscriptionViewModel = mapper.Map<InscriptionViewModel>(Inscription);
      InscriptionViewModel.Events = Context.Events.ToList().Select(Event =>
      new SelectListItem
      {
        Value = Event.Id.ToString(),
        Text = Event.Nome
      });

      InscriptionViewModel.Customers = Context.Customers.ToList().Select(Customer =>
        new SelectListItem
        {
          Value = Customer.Id.ToString(),
          Text = Customer.Nome
        });

      InscriptionViewModel.PaymentTypes = Context.PaymentTypes.ToList().Select(PaymentType =>
        new SelectListItem
        {
          Value = PaymentType.Id.ToString(),
          Text = PaymentType.Name
        });

      return InscriptionViewModel;
    }
    public InscriptionViewModel CreateViewModel(EscaladaContext Context)
    {
      InscriptionViewModel InscriptionViewModel = new InscriptionViewModel();
      InscriptionViewModel.Events = Context.Events.ToList().Select(Event =>
      new SelectListItem
      {
        Value = Event.Id.ToString(),
        Text = Event.Nome
      });

      InscriptionViewModel.Customers = Context.Customers.ToList().Select(Customer =>
        new SelectListItem
        {
          Value = Customer.Id.ToString(),
          Text = Customer.Nome
        });

      InscriptionViewModel.PaymentTypes = Context.PaymentTypes.ToList().Select(PaymentType =>
        new SelectListItem
        {
          Value = PaymentType.Id.ToString(),
          Text = PaymentType.Name
        });

      return InscriptionViewModel;
    }
    public string EventId { get; set; }
    public string CustomerId { get; set; }
    public string PaymentTypeId { get; set; }

    public IEnumerable<SelectListItem> Events { get; set; }
    public IEnumerable<SelectListItem> Customers { get; set; }
    public IEnumerable<SelectListItem> PaymentTypes { get; set; }

  }
}