using JogoVarejo.Shared.Models;
using JogoVarejo.Shared.Models.Utils;
using System.Threading.Tasks;

namespace JogoVarejo.Client.Services.Auth
{
    public interface IAuthService
    {
        Task<GenericResult<ApplicationUser>> Login(ApplicationUser usuario);
        Task Logout();
        Task<GenericResult<ApplicationUser>> Register(ApplicationUser usuario);
    }
}
