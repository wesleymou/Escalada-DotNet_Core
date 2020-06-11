using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Escalada.Models.ViewModels
{
    public static class InscriptionViewModelFactory
    {
        private static readonly MapperConfiguration _editConfig =
            new MapperConfiguration(cfg => cfg.CreateMap<Inscription, InscriptionEditViewModel>());

        public static InscriptionEditViewModel CreateEditViewModel(
            Inscription inscription,
            IEnumerable<Event> events,
            IEnumerable<PaymentType> paymentTypes,
            IEnumerable<Customer> customers)
        {
            InscriptionEditViewModel viewModel = inscription != null
                ? new Mapper(_editConfig).Map<InscriptionEditViewModel>(inscription)
                : new InscriptionEditViewModel();

            viewModel.EventListItems = events.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nome,
                Selected = viewModel.EventoId == e.Id,
            });
            
            viewModel.CustomerListItems = customers.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nome,
                Selected = viewModel.ClienteId == e.Id,
            });
            
            viewModel.PaymentTypeListItems = paymentTypes.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name,
                Selected = viewModel.TipoPagamentoId == e.Id,
            });

            return viewModel;
        }
    }
}