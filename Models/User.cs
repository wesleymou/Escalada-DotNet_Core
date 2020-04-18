using Microsoft.AspNetCore.Identity;

namespace Escalada.Models
{
  public class User : IdentityUser
  {
    public string login { get; set; }
    public string password { get; set; }
  }
}