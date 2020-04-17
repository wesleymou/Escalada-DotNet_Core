using System.ComponentModel.DataAnnotations;

namespace Escalada.Models
{
    public enum EventStatus
    {
        [Display(Name = "Em Espera")]
        EmEspera = 1,
        Pronto = 2
    }
}
