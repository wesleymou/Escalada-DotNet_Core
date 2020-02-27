using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Escalada_DotNet_Core.Models;

namespace Escalada_DotNet_Core.Service
{
    public class EscaladaContext : DbContext
    {
        public EscaladaContext(DbContextOptions<EscaladaContext> options) : base(options)
        {
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Provider> providers { get; set; }
        public DbSet<SubscriptionInEvents> subscriptionsInEvents { get; set; }
        public DbSet<SubscriptionProvider> subscriptionProviders { get; set; }
        public DbSet<PaymentType> paymentTypes { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Customer>().ToTable("Customer");
        // }
    }
}