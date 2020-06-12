using System.Linq;
using AutoMapper;
using Escalada.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Escalada.Models.ViewModels
{
    public class EventViewModelFactory
    {
        public static Event CreateModel(EscaladaContext Context, EventViewModel EventViewModel)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<EventViewModel, Event>()));

            Event Event = mapper.Map<Event>(EventViewModel);

            Event.Status = Context.EventStatus.FirstOrDefault(e => e.Id == int.Parse(EventViewModel.StatusId ?? "1"));
            return Event;
        }

        public static EventViewModel CreateViewModel(EscaladaContext Context, Event Event)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Event, EventViewModel>()));

            EventViewModel EventViewModel = mapper.Map<EventViewModel>(Event);
            EventViewModel.StatusId = Event.Status.Id.ToString();
            EventViewModel.StatusList = Context.EventStatus.ToList().Select(Status =>
            new SelectListItem
            {
                Value = Status.Id.ToString(),
                Text = Status.Name
            });
            return EventViewModel;
        }

        public static EventViewModel CreateViewModel(EscaladaContext Context)
        {
            EventViewModel EventViewModel = new EventViewModel();
            EventViewModel.StatusList = Context.EventStatus.ToList().Select(Status =>
            new SelectListItem
            {
                Value = Status.Id.ToString(),
                Text = Status.Name
            });
            return EventViewModel;
        }
    }
}