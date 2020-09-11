using JogoVarejo.Data;
using JogoVarejo.Server.Utils;
using JogoVarejo.Shared.Models;
using JogoVarejo.Shared.Models.Utils;
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
        public async Task<ActionResult<List<ApplicationUser>>> Login()
        {
            var usuario = await _userManager.Users
                .Where(u => u.TipoUsuarioId == 2).ToListAsync();
            return Ok(usuario);
          
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ApplicationUser>>> GetById( Guid userId)
        {
            try
            {
                var usuario = await _userManager.Users
               .Where(u => u.Id == userId.ToString()).FirstOrDefaultAsync();
                if (usuario == null)
                    return Ok(new GenericResult<ApplicationUser> {  Mensagem = "Usuário não encontrado", Sucesso = false });
                return Ok(new GenericResult<ApplicationUser> {  Sucesso = true, Item = usuario });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Mensagem = "Não foi possível atender essa solicitação! Tente novamente", Sucesso = false, Token = null });
            }
        }

        [HttpPut("usuarios")]
        public async Task<ActionResult> Put(ApplicationUser usuario)
        {
            var user = await _userManager
                .Users
                .SingleAsync(x => x.UserName == usuario.Login);

            if (user == null)
                return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, Mensagem = "Usuário não encontrado! Atualize o navegador e tente novamente." });

            try
            {
                var result = await _userManager.ChangePasswordAsync(user, user.Senha, usuario.Senha);

                if (!result.Succeeded)
                    return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, Mensagem = "Não foi possível alterar a senha" });

                var usr = await _userManager.FindByIdAsync(user.Id);
                usr.Senha = usuario.Senha;
                //usr.Nome = usuario.Nome;
                //usr.UserName = usuario.Login;
                usr.EmailConfirmed = true;
                await _userManager.UpdateAsync(usr);
                return Ok(new GenericResult<ApplicationUser> { Sucesso = true });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Mensagem = "Não foi possível atender essa solicitação! Tente novamente", Sucesso = false, Token = null });
            }
        }

        [HttpPost("deletar")]
        public async Task<ActionResult> Delete([FromBody] ApplicationUser usuario)
        {
            try
            {
                var user = await _userManager
                .Users
                .SingleAsync(x => x.UserName == usuario.Login);

                if (user == null)
                    return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, Mensagem = "Usuário não encontrado! Atualize o navegador e tente novamente." });

                await _userManager.DeleteAsync(user);
                return Ok(new GenericResult<ApplicationUser> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
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
                TipoUsuarioId = usuario.TipoUsuarioId,
                EmailConfirmed = true,
                LockoutEnabled = false,
                GrupoUsuarioId = usuario.GrupoUsuarioId,
            };


            var result = await _userManager.CreateAsync(user, usuario.Senha);
            if (!result.Succeeded)
                return Ok(new GenericResult<ApplicationUser> { Mensagem = "Erro", Sucesso = false });

            if (user.TipoUsuarioId == 1)
                await _userManager.AddToRoleAsync(user, "Professor");
            else
                await _userManager.AddToRoleAsync(user, "Aluno");

            return Ok(new GenericResult<ApplicationUser> { Sucesso = true });
        }

        //[HttpPut]
        //public async Task<ActionResult<Usuario>> Put(Usuario usuario)
        //{
        //    var user = await _userManager.Users
        //        .Include(g => g.Grupo)
        //        .SingleAsync(x => x.GrupoUsuarioId == usuario.GrupoUsuarioId);

        //    user.Grupo.GrupoOperadorId = usuario.Grupo.GrupoOperadorId;

        //    try
        //    {


        //        _db.Entry(user).State = EntityState.Modified;
        //        var result = await _userManager.UpdateAsync(user);


        //        return Ok(new LoginResult { Sucesso = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new LoginResult { Sucesso = false, Mensagem = ex.Message });
        //    }

        // }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ApplicationUser usuario)
        {
            var result = new GenericResult<ApplicationUser>();
            try
            {
                var user = await _userManager.Users
                 .FirstOrDefaultAsync(x => x.UserName == usuario.Login);

                if (user == null)
                    return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, Token = "", Mensagem = "Usuário não encontado!" });

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
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Mensagem = "Não foi possível atender essa solicitação! Tente novamente", Sucesso = false, Token = null });
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
