using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JogoVarejo.Server.Utils
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private const string adminId = "90e01617-8808-4552-b54b-ab30ee3ec275";
        private const string professorId = "94f5a22f-2ba6-40fc-a224-8c6ffc889881";
        private const string alunoId = "669d23f4-fc7a-40bb-84e5-06fe9b822525";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Id = adminId,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = professorId,
                        Name = "Professor",
                        NormalizedName = "PROFESSOR"
                    },
                    new IdentityRole
                    {
                        Id = alunoId,
                        Name = "Aluno",
                        NormalizedName = "ALUNO"
                    }
                );
        }
    }
}
