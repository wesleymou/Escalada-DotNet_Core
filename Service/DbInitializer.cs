using System;
using System.Linq;
using Escalada.Models;

namespace Escalada.Service
{
    public static class DbInitializer
    {
        public static void Initialize(EscaladaContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customers.Any())
            {
                return; // DB has been seeded
            }

            context.Customers.Add(new Customer
            {
                Nome = "Kyouko",
                Cpf = "1345678901",
                Endereco = "Distrito de Sangatsu",
                Email = "kyouko@gmail.com",
                NumFone1 = "31988887777"
            });

            context.Providers.Add(new Provider
            {
                Id = 1,
                Name = "Transpost"
            });

            context.Events.Add(new Event
            {
                Capacidade = 1,
                DataInicio = DateTime.Now,
                DataTermino = DateTime.Now,
                Local = "Distrito de Sangatsu",
                OrcamentoPrevio = 4.5m,
                ValorIngresso = 4.5m,
                Nome = "Visita",
                Quorum = 1,
                Status = EventStatus.EmEspera
            });

            context.Users.Add(new User
            {
                login = "admin",
                password = "14159265358979323"
            });

            context.SaveChanges();
        }
    }
}