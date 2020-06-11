using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escalada.Service;

namespace Escalada.Models.ViewModels
{
    public class EventViewModel : Event
    {
        public string StatusId { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
    }
}