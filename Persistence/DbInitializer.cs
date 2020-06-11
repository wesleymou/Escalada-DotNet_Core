using System;
using System.Linq;
using Escalada.Models;

namespace Escalada.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(EscaladaContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (!context.PaymentTypes.Any())
            {
                context.PaymentTypes.Add(new PaymentType
                {
                    Name = "Dinheiro"
                });

                context.PaymentTypes.Add(new PaymentType
                {
                    Name = "Débito"
                });

                context.PaymentTypes.Add(new PaymentType
                {
                    Name = "Crédito"
                });
            }

            var eventStatus = new EventStatus
            {
                Name = "Em espera"
            };
            if (!context.EventStatus.Any())
            {
                context.EventStatus.Add(eventStatus);

                context.EventStatus.Add(new EventStatus
                {
                    Name = "Pronto"
                });
            }

            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer
                {
                    Nome = "Kyouko",
                    Cpf = "1345678901",
                    Endereco = "Distrito de Sangatsu",
                    Email = "kyouko@gmail.com",
                    NumFone1 = "31988887777"
                });
            }

            if (!context.Providers.Any())
            {
                context.Providers.Add(new Provider
                {
                    Name = "Transpost"
                });
            }

            if (!context.Events.Any())
            {
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
                    Status = eventStatus
                });
            }

            // if (!context.Users.Any())
            // {
            //     context.Users.Add(new User
            //     {
            //         login = "admin",
            //         password = "admin"
            //     });
            // }

            context.SaveChanges();
        }
    }
}