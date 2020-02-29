using Escalada.Models;

namespace Escalada.Models
{
    public class Agreement
    {
        public int id { get; set; }
        public Provider providerId { get; set; }
        public Event eventId;
    }
}