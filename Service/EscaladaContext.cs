using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Escalada_DotNet_Core.Models;

namespace Escalada_DotNet_Core.Service
{
    public class EscaladaContext : DbContext
    {
        public EscaladaContext() : base("EscaladaContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<SubscriptionProvider> SubscriptionProviders { get; set; }
        
        // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {
        //     modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        // }
    }
}