using JogoVarejo_Server.Server.Data;
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

        //[HttpGet]
        //public async Task<ActionResult<List<Usuario>>> Get()
        //{
        //    var list = await _context.Grupos.AsNoTracking().ToListAsync();
        //    return Ok(list);
        //}

        //[HttpGet("gerente/{userId}")]
        //public async Task<ActionResult<List<Usuario>>> GetUsuario(Guid userId)
        //{
        //    var user = await _context.Users.Include(x => x.Grupos)
        //        .SingleAsync(x => x.Id == userId.ToString());

        //    var item = await _context.T_grupos.AsNoTracking().SingleOrDefaultAsync(x => x.GruposId == user.Grupos.GruposId);
        //    return Ok(item);
        //}

        //[HttpGet("operador/{userId}")]
        //public async Task<ActionResult<List<Usuario>>> GetOperador(Guid userId, int id = 0)
        //{
        //    var user = await _context.Users.Include(x => x.Grupos)
        //        .SingleAsync(x => x.Id == userId.ToString());

        //    var itm = await _context.T_grupos
        //       .Where(x => x.GruposOperadorId == user.Grupos.GruposUsuarioId).FirstOrDefaultAsync();

        //    var grupos = new JogoVarejo_Server.Shared.Models.Grupos
        //    {
        //        GruposId = itm.GruposId,
        //        GruposOperadorId = itm.GruposUsuarioId,
        //        GruposUsuarioId = itm.GruposOperadorId,
        //        Quando = itm.Quando,
        //        Quanto = itm.Quanto
        //    };

        //    return Ok(grupos);
        //}


        //[HttpPost("deletar")]
        //public async Task<ActionResult> Delete([FromBody] JogoVarejo_Server.Shared.Models.Grupos grupos)
        //{
        //    var grp = await _context.T_grupos
        //        .FirstOrDefaultAsync(x => x.GruposId == grupos.GruposId);

        //    _context.Remove(grp);
        //    await _context.SaveChangesAsync();
        //    return Ok(new GenericResult<JogoVarejo_Server.Shared.Models.Grupos> { Sucesso = true, obj = grp });
        //}

        //[HttpPut]
        //public async Task<ActionResult<JogoVarejo_Server.Shared.Models.Grupos>> Put([FromBody] JogoVarejo_Server.Shared.Models.Grupos grupos)
        //{
        //    _context.Entry(grupos).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return Ok(new GenericResult<JogoVarejo_Server.Shared.Models.Grupos> { Sucesso = true });
        //}
    }
}
