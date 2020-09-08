using JogoVarejo.Data;
using JogoVarejo.Server.Utils;
using JogoVarejo.Shared.Models;
using JogoVarejo_Server.Shared.Models.Utils;
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

namespace JogoVarejo.Server.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AcessoController : ControllerBase
    {
        readonly AppDbContext _db;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly UserManager<ApplicationUser> _userManager;
        readonly AppSettings _appSettings;


        public AcessoController(
                                AppDbContext db,
                                SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,
                                IOptions<AppSettings> appSettings)

        {
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }



        [HttpGet("usuarios")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> Login()
        {
            try
            {
                var usuarios = await _userManager.Users
                 .Include(g => g.Grupo)
                 .Where(u => u.TipoUsuarioId == 2).ToListAsync();

                if (!usuarios.Any())
                    return Ok(new GenericResult<ApplicationUser> { Sucesso = false, MensagemErro = "Não há registros no Banco de dados" });
                else
                    return Ok(new GenericResult<ApplicationUser> { Sucesso = true, Items = usuarios });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
            }
        }


        [HttpPost("deletar")]
        public async Task<ActionResult> Delete([FromBody] ApplicationUser usuario)
        {
            try
            {
                var user = await _userManager
                   .Users
                   .Include(g => g.Grupo)
                   .SingleAsync(x => x.GrupoUsuarioId == usuario.GrupoUsuarioId);

                var result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)

                    return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Verifique se os dados estão corretos e tente novamente." });
                return Ok(new GenericResult<ApplicationUser> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
            }
        }


        [HttpPost("register")]
        public async Task<ActionResult> Post([FromBody] ApplicationUser usuario)
        {
            var user = new ApplicationUser
            {
                Nome = usuario.Nome,
                Login = usuario.Login,
                UserName = usuario.Login,
                Email = usuario.Login,
                Senha = usuario.Senha,
                GrupoUsuarioId = usuario.GrupoUsuarioId,
                TipoUsuarioId = usuario.TipoUsuarioId,

                Grupo = new Grupo
                {
                    GrupoUsuarioNome = usuario.Nome,
                    GrupoUsuarioId = usuario.GrupoUsuarioId,
                    OperadorId = 0,
                }
            };

            try
            {
                var result = await _userManager.CreateAsync(user, usuario.Senha);
                if (!result.Succeeded)
                    return BadRequest(new GenericResult<ApplicationUser> { MensagemErro = "Não foi possível atender essa requisição. verifique se não existe esse usuário e tente novamente.", Sucesso = false });

                if (user.TipoUsuarioId == 1)
                    await _userManager.AddToRoleAsync(user, "Professor");
                else
                    await _userManager.AddToRoleAsync(user, "Aluno");

                return Ok(new GenericResult<ApplicationUser> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
            }
        }


        [HttpPut]
        public async Task<ActionResult<ApplicationUser>> Put(ApplicationUser usuario)
        {
            try
            {
                var user = await _userManager.Users
                .Include(g => g.Grupo)
                .SingleAsync(x => x.GrupoUsuarioId == usuario.GrupoUsuarioId);

                user.Grupo.OperadorId = usuario.Grupo.OperadorId;

                _db.Entry(user).State = EntityState.Modified;
                var result = await _userManager.UpdateAsync(user);

                return Ok(new GenericResult<ApplicationUser> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ApplicationUser usuario)
        {
            try
            {
                var user = await _userManager.Users
                 .FirstOrDefaultAsync(x => x.UserName == usuario.Login);

                if (user == null)
                    return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, Token = "", MensagemErro = "Usuário não encontado!" });

                var result  = await _userManager.CheckPasswordAsync(user, usuario.Senha);

                if (!result)
                    return BadRequest(new GenericResult<ApplicationUser>{ Sucesso = false, MensagemErro = "Verifique se os dados informados estão corretos e tente novamente!" });

                return Ok(new GenericResult<ApplicationUser> { Sucesso = true, Token = await GenerateTokenAsync(user)});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
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
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

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
