using JogoVarejo.Data;
using JogoVarejo.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JogoVarejo.Server.Utils
{
    public class SetAdmin
    {
        private AppDbContext _context;

        public SetAdmin(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAdminUser()
        {
            var user = new ApplicationUser
            {
                Nome = "Admin",
                Login = "Email@email.com",
                UserName = "Email@email.com",
                NormalizedUserName = "email@email.com",
                Email = "Email@email.com",
                NormalizedEmail = "email@email.com",
                EmailConfirmed = true,
                TipoUsuarioId = 1,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "Admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
                await roleStore.CreateAsync(new IdentityRole { Name = "Professor", NormalizedName = "PROFESSOR" });
                await roleStore.CreateAsync(new IdentityRole { Name = "Aluno", NormalizedName = "ALUNO" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
               var hashed = password.HashPassword(user, "1q2w3e4r");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(_context);
                await userStore.CreateAsync(user);

                await userStore.AddToRoleAsync(user, "Admin");
                await userStore.AddToRoleAsync(user, "Professor");
            }
            await _context.SaveChangesAsync();
        }
    }
}