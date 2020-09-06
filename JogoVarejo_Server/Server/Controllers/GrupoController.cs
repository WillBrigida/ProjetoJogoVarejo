using JogoVarejo_Server.Server.Data;
using JogoVarejo_Server.Server.Migrations;
using JogoVarejo_Server.Shared.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("deletar")]
        public async Task<ActionResult> Delete([FromBody] JogoVarejo_Server.Shared.Models.Grupo grupo)
        {
            var grp = await _context.T_grupo
                .FirstOrDefaultAsync(x => x.GrupoId == grupo.GrupoId);

            _context.Remove(grp);
            await _context.SaveChangesAsync();
            return Ok(new GenericResult<JogoVarejo_Server.Shared.Models.Grupo> {Sucesso = true, obj = grp });
        }
    }
}
