using System;
using System.Linq;
using Escalada_DotNet_Core.Models;

namespace Escalada_DotNet_Core.Service {
    public static class DbInitializer {
        public static void Initialize (EscaladaContext context) {
            context.Database.EnsureCreated ();

            // Look for any students.
            if (context.customers.Any ()) {
                return; // DB has been seeded
            }

            uint[] cp = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 };
            var customers = new Customer[] {
                new Customer (
                cp,
                "Kyouko",
                cp,
                cp,
                "Distrito de Sangatsu",
                "kyouko@gmail.com"
                )
            };
            foreach (Customer c in customers) {
                context.customers.Add (c);
            }
            context.SaveChanges ();

            var providers = new Provider[] {
                new Provider ()
            };
            foreach (Provider p in providers) {
                context.providers.Add (p);
            }
            context.SaveChanges ();

            var events = new Event[] {
                new Event {
                capacidade = 1,
                dataInicio = DateTime.Now,
                dataTermino = DateTime.Now,
                local = "Distrito de Sangatsu",
                orcamentoPrevio = 4.5m,
                valorIngresso = 4.5m,
                nome = "Visita",
                quorum = 1,
                status = "Pronto"
                }
            };
            foreach (Event e in events) {
                context.events.Add (e);
            }
            context.SaveChanges ();
        }
    }
}