using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escalada.Service;
using AutoMapper;

namespace Escalada.Models.ViewModels
{
    public class InscriptionViewModel : Inscription
    {
        public string EventId { get; set; }
        public string CustomerId { get; set; }
        public string PaymentTypeId { get; set; }

        public IEnumerable<Event> AllEvents { get; set; }

        public IEnumerable<SelectListItem> Events { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }

    }
}