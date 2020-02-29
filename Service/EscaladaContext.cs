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
        public DbSet<Customer> customers { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Provider> providers { get; set; }
        public DbSet<Inscription> inscription { get; set; }
        public DbSet<Agreement> agreement { get; set; }
        public DbSet<PaymentType> paymentTypes { get; set; }
        public DbSet<User> users {get;set;}

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Customer>().ToTable("Customer");
    // }
}
}