using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Escalada.Models.ViewModels
{
    public class EventEditViewModel : Event
    {
        public int StatusId { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
    }
}