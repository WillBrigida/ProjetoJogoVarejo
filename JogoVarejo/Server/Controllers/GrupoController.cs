using JogoVarejo.Data;
using JogoVarejo.Shared.Models;
using JogoVarejo_Server.Shared.Models.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoVarejo.Server.Controllers
{
    [ApiController]
    [Route("api/v1/grupo")]
    public class GrupoController : ControllerBase
    {
        readonly AppDbContext _context;
        public GrupoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grupo>>> Get()
        {
            try
            {
                var grupos = await _context.T_grupo.AsNoTracking().ToListAsync();

                if (!grupos.Any())
                    return Ok(new GenericResult<Grupo> { Sucesso = false, MensagemErro = "Não há registros no Banco de dados" });
                else
                    return Ok(new GenericResult<Grupo> { Sucesso = true, Items = grupos });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<ApplicationUser> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
            }
        }

        [HttpGet("gerente/{userId}")]
        public async Task<ActionResult<IEnumerable<Grupo>>> GetUsuario(Guid userId)
        {
            var user = await _context.Users.Include(x => x.Grupo)
                .SingleAsync(x => x.Id == userId.ToString());

            var item = await _context.T_grupo.AsNoTracking().SingleOrDefaultAsync(x => x.GrupoId == user.Grupo.GrupoId);
            return Ok(item);
        }

        [HttpGet("operador/{userId}")]
        public async Task<ActionResult<Grupo>> GetOperador(Guid userId)
        {
            try
            {
                var user = await _context.Users.Include(x => x.Grupo)
               .SingleAsync(x => x.Id == userId.ToString());

                var grupo = await _context.T_grupo
                   .Where(x => x.OperadorId == user.Grupo.GrupoUsuarioId).FirstOrDefaultAsync();

                if (grupo == null)
                    return Ok(new GenericResult<Grupo> { Sucesso = false, MensagemErro = "Não há registros no Banco de dados" });

                var newGrupo = new Grupo
                {
                    GrupoId = grupo.GrupoId,
                    OperadorId = grupo.GrupoUsuarioId,
                    GrupoUsuarioId = grupo.OperadorId,
                    Quando = grupo.Quando,
                    Quanto = grupo.Quanto
                };

                return Ok(new GenericResult<Grupo> { Sucesso = true, Item = newGrupo });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Grupo> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
            }
        }


        [HttpPost("deletar")]
        public async Task<ActionResult> Delete([FromBody] Grupo grupo)
        {
            try
            {
                var grp = await _context.T_grupo
               .FirstOrDefaultAsync(x => x.GrupoId == grupo.GrupoId);

                _context.Remove(grp);
                await _context.SaveChangesAsync();
                return Ok(new GenericResult<Grupo> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Grupo> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
            }
        }


        [HttpPut]
        public async Task<ActionResult<Grupo>> Put([FromBody] Grupo grupo)
        {
            try
            {
                _context.Entry(grupo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new GenericResult<Grupo> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Grupo> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
            }
        }
    }
}
