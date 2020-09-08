using JogoVarejo_Server.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JogoVarejo_Server.Client.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> Login(Usuario usuario);
        Task Logout();
        Task<CadastroResult> Register(Usuario usuario);
    }
}
