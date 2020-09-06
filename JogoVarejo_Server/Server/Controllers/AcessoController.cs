using JogoVarejo_Server.Server.Utils;
using JogoVarejo_Server.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JogoVarejo_Server.Server.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AcessoController : ControllerBase
    {
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly UserManager<ApplicationUser> _userManager;
        readonly AppSettings _appSettings;


        public AcessoController(
                                SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,
                                IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }



        //[HttpGet("modelo")]
        //public async Task<ActionResult> GetModelo()
        //{
        //    var claimsIdentity = this.User.Identity as ClaimsIdentity;
        //    var userId = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        //    var userId1 = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var userId2 = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

        //    return base.Ok(new Usuario());
        //}

        [HttpGet("usuarios")]
        public async Task<ActionResult<List<Usuario>>> Login()
        {
            var usuario = await _userManager.Users.Where(u => u.TipoUsuarioId == 2).ToListAsync();

            var listUsuario = new List<Usuario>();
            foreach (var item in usuario)
            {
                listUsuario.Add(new Usuario
                {
                    GrupoUsuarioId = item.GrupoUsuarioId,
                    Nome = item.Nome,
                    Login = item.Login,
                    TipoUsuarioId = item.TipoUsuarioId,
                    Senha = item.Senha
                });
            }
            return listUsuario;
        }

        [HttpPost("deletar")]

        public async Task<ActionResult> Delete([FromBody] Usuario usuario)
        {
            var user = await _userManager.Users.Where(x => x.GrupoUsuarioId == usuario.GrupoUsuarioId).FirstOrDefaultAsync();
            await _userManager.DeleteAsync(user);

            return Ok();
        }


        [HttpPost("register")]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            var user = new ApplicationUser
            {
                Nome = usuario.Nome,
                Login = usuario.Login,
                UserName = usuario.Login,
                Email = usuario.Login,
                Senha = usuario.Senha,
                GrupoUsuarioId = usuario.GrupoUsuarioId,
                TipoUsuarioId = usuario.TipoUsuarioId
            };

            var result = await _userManager.CreateAsync(user, usuario.Senha);
            if (!result.Succeeded)
                return Ok(new CadastroResult { Erro = "Erro", Sucesso = false });

            if (user.TipoUsuarioId == 1)
                await _userManager.AddToRoleAsync(user, "Professor");
            else
                await _userManager.AddToRoleAsync(user, "Aluno");

            return Ok(new CadastroResult { Sucesso = true });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var result = new LoginResult();
            try
            {
                var user = await _userManager.Users
                 .FirstOrDefaultAsync(x => x.UserName == usuario.Login);

                if (user == null)
                    return BadRequest(new LoginResult { Sucesso = false, Token = "", Mensagem = "Usuário não encontado!" });

                if (await _userManager.CheckPasswordAsync(user, usuario.Senha))
                {
                    result.Token = await GenerateTokenAsync(user);
                    result.Sucesso = true;
                }
                else
                {
                    result.Token = "";
                    result.Sucesso = false;
                    result.Mensagem = "Verifique se os dados informados estão corretos e tente novamente!";
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResult { Mensagem = ex.Message, Sucesso = false, Token = null });
            }

        }

        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            if (user.Nome.Contains("Admin"))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                await _userManager.AddToRoleAsync(user, "Professor");
            }

            var roles = await _signInManager.UserManager.GetRolesAsync(user);

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.UserName));

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras);

            JwtSecurityToken token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
