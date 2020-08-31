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



        [HttpGet("modelo")]
        public async Task<ActionResult> GetModelo()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            var userId1 = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId2 = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

            return base.Ok(new Usuario());
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
            };

            var result = await _userManager.CreateAsync(user, usuario.Senha);
            if (result.Succeeded)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            //Removendo propriedades desnecessárias
            //ModelState.Remove("Nome");
            //ModelState.Remove("Sobrenome");
            //ModelState.Remove("ConfirmarSenha");
            //ModelState.Remove("Apartamento");

            var user = await _userManager.Users
                  .FirstOrDefaultAsync(x => x.UserName == usuario.Login);

            if (await _userManager.CheckPasswordAsync(user, usuario.Senha))
                return Ok(new LoginResult { Token = await GenerateTokenAsync(user) });
            else
            {
                //logando o usuario
                //await _signInManager.SignInAsync(usuario, false);
                return BadRequest("Erro");
            }
        }

        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
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
