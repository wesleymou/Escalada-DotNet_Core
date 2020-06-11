using Escalada.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escalada.Persistence
{
    class IdentityInitializer : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    UserName = "Administrator",
                    NormalizedUserName = "ADMINISTRATOR",
                    Email = "admin@email.com",
                    NormalizedEmail = "ADMIN@EMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEAdCtP6Rzb3My26JN4o5MKxExb8Du3j/C1BOuyL4bJtZRV/t4o8Jda58A1l3opNMvw==",
                    LockoutEnabled = true
                }
            );
        }
    }
}