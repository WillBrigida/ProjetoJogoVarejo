using JogoVarejo.Models;
using JogoVarejo.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JogoVarejo.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        //public DbSet<Controle> T_controle { get; set; }
        //public DbSet<Grupo> T_grupo{ get; set; }
    }
}
