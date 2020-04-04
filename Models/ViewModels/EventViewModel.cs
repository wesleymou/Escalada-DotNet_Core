using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Escalada.Models.ViewModels
{
    public class EventViewModel : Event
    {
        public string StatusId { get; set; }
        public IEnumerable<SelectListItem> All { get; } = EventStatus.All.Select(status =>
        new SelectListItem
        {
            Value = status.Id.ToString(),
            Text = status.Nome
        });
    }
}