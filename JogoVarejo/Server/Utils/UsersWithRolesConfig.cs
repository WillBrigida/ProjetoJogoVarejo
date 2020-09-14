using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JogoVarejo.Server.Utils
{
    public class UsersWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {

        private const string userAdminId = "a75f5d19-0b3f-4481-af1d-b24c95cdad9b";

        private const string adminRoleId = "90e01617-8808-4552-b54b-ab30ee3ec275";
        private const string professorId = "94f5a22f-2ba6-40fc-a224-8c6ffc889881";
        private const string alunoId = "669d23f4-fc7a-40bb-84e5-06fe9b822525";


        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            IdentityUserRole<string> iur = new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userAdminId
            };

            //IdentityUserRole<string> iu4 = new IdentityUserRole<string>
            //{
            //    RoleId = professorId,
            //    UserId = userAdminId
            //};

            builder.HasData(iur);
            //builder.HasData(iu4);
        }
    }
}
