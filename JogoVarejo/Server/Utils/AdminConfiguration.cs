using JogoVarejo.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JogoVarejo.Server.Utils
{
    public class AdminConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private const string userAdminId = "a75f5d19-0b3f-4481-af1d-b24c95cdad9b";

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser
            {
                Id = userAdminId    ,
                Nome = "Admin",
                Login = "Email@email.com",
                UserName = "Email@email.com",
                NormalizedUserName = "email@email.com",
                Email = "Email@email.com",
                NormalizedEmail = "email@email.com",
                EmailConfirmed = true,
                TipoUsuarioId = 1,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            admin.PasswordHash = PassGenerate(admin);

            builder.HasData(admin);
        }

        public string PassGenerate(ApplicationUser user)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, "password");
        }
    }
}