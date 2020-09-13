using JogoVarejo.Data;
using JogoVarejo.Shared.Models;
using JogoVarejo.Shared.Models.Utils;
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
        public async Task<ActionResult<List<Grupos>>> Get()
        {
            try
            {
                var grupos = await _context.Grupos.AsNoTracking().ToListAsync();
                if (grupos == null)
                    return Ok(new GenericResult<Grupos> { Sucesso = false, Mensagem = "Não há registro(s)!" });
                return Ok(new GenericResult<Grupos> { Sucesso = true, Items = grupos });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Grupos> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Grupos>>> GetGrupo(int id)
        {
            try
            {
                var grupo = await _context.Grupos
               .Where(x => x.GrupoId == id)
               .FirstOrDefaultAsync();
                if (grupo == null)
                    return Ok(new GenericResult<Grupos> { Sucesso = false, Mensagem = "Usuário não encontrado" });
                return Ok(new GenericResult<Grupos> { Sucesso = true, Item = grupo });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Grupos> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }

        }

        [HttpGet("operador/{userId}")]
        public async Task<ActionResult<List<ApplicationUser>>> GetOperador(Guid userId)
        {


            var user = await _context.Users
                .SingleAsync(x => x.Id == userId.ToString());

            var itm = await _context.Grupos
               .Where(x => x.GrupoOperador == user.GrupoUsuarioId).FirstOrDefaultAsync();

            var grupos = new Grupos
            {
                GrupoOperador = itm.GrupoId,
                GrupoId = (int)itm.GrupoOperador,
                Quando = itm.Quando,
                Quanto = itm.Quanto
            };

            return Ok(grupos);
        }


        //[HttpPost("deletar")]
        //public async Task<ActionResult> Delete([FromBody] JogoVarejo_Server.Shared.Models.Grupos grupos)
        //{
        //    var grp = await _context.T_grupos
        //        .FirstOrDefaultAsync(x => x.GruposId == grupos.GruposId);

        //    _context.Remove(grp);
        //    await _context.SaveChangesAsync();
        //    return Ok(new GenericResult<JogoVarejo_Server.Shared.Models.Grupos> { Sucesso = true, obj = grp });
        //}

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Grupos grupos)
        {
            try
            {
                _context.Entry(grupos).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new GenericResult<Grupos> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Grupos> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }
        }
    }
}
