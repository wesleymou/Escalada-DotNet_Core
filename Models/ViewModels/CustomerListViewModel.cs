using System.Collections.Generic;

namespace Escalada.Models.ViewModels
{
    public class CustomerListViewModel
    {
        public List<Customer> Customers { get; set; }
        public bool ShowDeleted { get; set; }
    }
}