using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Escalada.Models.ViewModels
{
    public static class EventViewModelFactory
    {
        private static readonly MapperConfiguration _editMapConfig = new MapperConfiguration(config =>
            config.CreateMap<Event, EventEditViewModel>());

        public static EventEditViewModel CreateEditViewModel(Event @event, IEnumerable<EventStatus> statuses)
        {
            var viewModel = @event != null
                ? new Mapper(_editMapConfig).Map<EventEditViewModel>(@event)
                : new EventEditViewModel();

            viewModel.StatusId = @event?.Status?.Id ?? 0;
            viewModel.StatusList = statuses.Select(status => new SelectListItem
            {
                Value = status.Id.ToString(),
                Text = status.Name,
                Selected = @event?.Status?.Id == status.Id,
            });

            return viewModel;
        }
    }
}