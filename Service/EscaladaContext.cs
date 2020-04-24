using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Escalada.Models;

namespace Escalada.Service
{
  public class EscaladaContext : DbContext
  {
    public EscaladaContext(DbContextOptions<EscaladaContext> options) : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Inscription> Inscriptions { get; set; }
    public DbSet<Agreement> Agreements { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<EventStatus> EventStatus { get; set; }

  }
}