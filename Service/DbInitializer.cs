using System;
using System.Linq;
using Escalada_DotNet_Core.Models;

namespace Escalada_DotNet_Core.Service
{
    public static class DbInitializer
    {
        public static void Initialize(EscaladaContext context)
        {
            // context.Database.EnsureCreated ();

            // Look for any students.
            if (context.customers.Any()) {
                return; // DB has been seeded
            }

            uint[] cp = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 };
            var customer = new Customer(
                cp,
                "Kyouko",
                cp,
                cp,
                "Distrito de Sangatsu",
                "kyouko@gmail.com"
                );

            context.customers.Add(customer);

            var provider = new Provider
            {
                name = "Transpost"
            };

            context.providers.Add(provider);

            var eventt = new Event
            {
                capacidade = 1,
                dataInicio = DateTime.Now,
                dataTermino = DateTime.Now,
                local = "Distrito de Sangatsu",
                orcamentoPrevio = 4.5m,
                valorIngresso = 4.5m,
                nome = "Visita",
                quorum = 1,
                status = "Pronto"
            };

            context.events.Add(eventt);

            var user = new User
            {
                login = "admin",
                password = "14159265358979323"
            };
            context.users.Add(user);

            context.SaveChanges();
        }
    }
}