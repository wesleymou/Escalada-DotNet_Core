using System.Linq;
using AutoMapper;
using Escalada.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Escalada.Models.ViewModels
{
    class InscriptionViewModelFactory
    {
        public static Inscription CreateModel(EscaladaContext Context, InscriptionViewModel InscriptionViewModel)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<InscriptionViewModel, Inscription>()));

            Inscription Inscription = mapper.Map<Inscription>(InscriptionViewModel);

            Inscription.Cliente = Context.Customers.FirstOrDefault(c => c.Id == int.Parse(InscriptionViewModel.CustomerId ?? "1"));
            Inscription.Evento = Context.Events.FirstOrDefault(e => e.Id == int.Parse(InscriptionViewModel.EventId ?? "1"));
            Inscription.TipoPagamento = Context.PaymentTypes.FirstOrDefault(p => p.Id == int.Parse(InscriptionViewModel.PaymentTypeId ?? "1"));
            return Inscription;
        }

        public static InscriptionViewModel CreateViewModel(EscaladaContext Context, Inscription Inscription)
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

        public static InscriptionViewModel CreateViewModel(EscaladaContext Context)
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
    }
}