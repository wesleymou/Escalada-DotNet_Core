
using System.Collections.Generic;
using System.ComponentModel;

namespace Escalada.Models
{
    public class EventStatus
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static List<EventStatus> All { get; } = new List<EventStatus>
        {
            new EventStatus
            {
                Id = 1,
                Nome = "Em espera"
            },
            new EventStatus
            {
                Id = 2,
                Nome = "Pronto"
            }
        };
    }
}
