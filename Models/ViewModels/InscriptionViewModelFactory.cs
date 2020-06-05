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

            viewModel.CustomerId = inscription?.Cliente?.Id ?? 0;
            viewModel.EventId = inscription?.Evento?.Id ?? 0;
            viewModel.PaymentTypeId = inscription?.TipoPagamento?.Id ?? 0;
            
            viewModel.EventListItems = events.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nome,
                Selected = viewModel.EventId == e.Id,
            });
            
            viewModel.CustomerListItems = customers.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nome,
                Selected = viewModel.CustomerId == e.Id,
            });
            
            viewModel.PaymentTypeListItems = paymentTypes.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name,
                Selected = viewModel.PaymentTypeId == e.Id,
            });

            return viewModel;
        }
    }
}