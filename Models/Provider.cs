using System.Collections.Generic;

namespace Escalada.Models
{
    public class Provider
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Agreement> agreementId { get; set; }
    }
}