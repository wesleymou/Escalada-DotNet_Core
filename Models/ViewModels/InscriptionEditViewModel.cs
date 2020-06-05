using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;

namespace Escalada.Models.ViewModels
{
    public class InscriptionEditViewModel : Inscription
    {
        public int EventId { get; set; }
        public int CustomerId { get; set; }
        public int PaymentTypeId { get; set; }

        public IEnumerable<SelectListItem> EventListItems { get; set; }
        public IEnumerable<SelectListItem> CustomerListItems { get; set; }
        public IEnumerable<SelectListItem> PaymentTypeListItems { get; set; }

    }
}