using JogoVarejo_Server.Server.Data;
using JogoVarejo_Server.Server.Migrations;
using JogoVarejo_Server.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using JogoVarejo_Server.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoVarejo_Server.Server.Controllers
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
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var list = await _context.T_grupo.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        [HttpGet("gerente/{userId}")]
        public async Task<ActionResult<List<Usuario>>> GetUsuario(Guid userId)
        {
            var user = await _context.Users.Include(x => x.Grupo)
                .SingleAsync(x => x.Id == userId.ToString());

            var item = await _context.T_grupo.AsNoTracking().SingleOrDefaultAsync(x => x.GrupoId == user.Grupo.GrupoId);
            return Ok(item);
        }

        [HttpGet("operador/{userId}")]
        public async Task<ActionResult<List<Usuario>>> GetOperador(Guid userId, int id = 0)
        {
            var user = await _context.Users.Include(x => x.Grupo)
                .SingleAsync(x => x.Id == userId.ToString());

            var itm = await _context.T_grupo
               .Where(x => x.GrupoOperadorId == user.Grupo.GrupoUsuarioId).FirstOrDefaultAsync();

            var grupo = new JogoVarejo_Server.Shared.Models.Grupo
            {
                GrupoId = itm.GrupoId,
                GrupoOperadorId = itm.GrupoUsuarioId,
                GrupoUsuarioId = itm.GrupoOperadorId,
                Quando = itm.Quando,
                Quanto = itm.Quanto
            };

            return Ok(grupo);
        }


        [HttpPost("deletar")]
        public async Task<ActionResult> Delete([FromBody] JogoVarejo_Server.Shared.Models.Grupo grupo)
        {
            var grp = await _context.T_grupo
                .FirstOrDefaultAsync(x => x.GrupoId == grupo.GrupoId);

            _context.Remove(grp);
            await _context.SaveChangesAsync();
            return Ok(new GenericResult<JogoVarejo_Server.Shared.Models.Grupo> { Sucesso = true, obj = grp });
        }

        [HttpPut]
        public async Task<ActionResult<JogoVarejo_Server.Shared.Models.Grupo>> Put([FromBody] JogoVarejo_Server.Shared.Models.Grupo grupo)
        {
            _context.Entry(grupo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new GenericResult<JogoVarejo_Server.Shared.Models.Grupo> { Sucesso = true });
        }
    }
}
