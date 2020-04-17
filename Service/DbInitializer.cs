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
      if (!context.PaymentTypes.Any())
      {
        context.PaymentTypes.Add(new PaymentType
        {
          Description = "Dinheiro"
        });

        context.PaymentTypes.Add(new PaymentType
        {
          Description = "Débito"
        });

        context.PaymentTypes.Add(new PaymentType
        {
          Description = "Crédito"
        });
      }

      if (!context.EventStatus.Any())
      {
        context.EventStatus.Add(new EventStatus
        {
          Nome = "Em espera"
        });

        context.EventStatus.Add(new EventStatus
        {
          Nome = "Pronto"
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
          Status = context.EventStatus.FirstOrDefault(s => s.Id == 1)
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