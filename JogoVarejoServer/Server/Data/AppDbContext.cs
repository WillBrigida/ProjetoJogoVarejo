using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JogoVarejoServer.Shared.Models;

namespace Server.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
          public AppDbContext(DbContextOptions options) : base(options) { }
    }
}