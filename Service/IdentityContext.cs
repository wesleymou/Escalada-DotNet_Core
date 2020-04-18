
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Escalada.Models;


namespace Escalada.Service
{
  public class IdentityContext : IdentityDbContext<User>
  {
    public DbSet<User> User { get; set; }
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}