using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escalada.Service;
using AutoMapper;

namespace Escalada.Models.ViewModels
{
  public class EventViewModel : Event
  {
    public Event CreateModel(EscaladaContext Context)
    {
      this.Status = Context.EventStatus.FirstOrDefault(e => e.Id == int.Parse(this.StatusId ?? "1"));
      return this;
    }

    public EventViewModel CreateViewModel(EscaladaContext Context, Event Event)
    {
      var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Event, EventViewModel>()));

      EventViewModel EventViewModel = mapper.Map<EventViewModel>(Event);
      EventViewModel.StatusList = Context.EventStatus.ToList().Select(Status =>
      new SelectListItem
      {
        Value = Status.Id.ToString(),
        Text = Status.Name
      });
      return EventViewModel;
    }

    public EventViewModel CreateViewModel(EscaladaContext Context)
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

    public string StatusId { get; set; }
    public IEnumerable<SelectListItem> StatusList { get; set; }
  }
}