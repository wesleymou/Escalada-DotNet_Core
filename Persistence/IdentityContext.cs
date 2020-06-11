using Escalada.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Escalada.Persistence
{
  public class IdentityContext : IdentityDbContext<User>
  {
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.ApplyConfiguration(new IdentityInitializer());
    }
  }
}