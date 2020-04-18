using System.Collections.Generic;

namespace Escalada.Models
{
  public class Provider
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Excluido { get; set; }
    public ICollection<Agreement> AgreementId { get; set; }
  }
}
