using JogoVarejo_Server.Server.Data;
using JogoVarejo_Server.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JogoVarejo_Server.Server.Controllers
{
    [ApiController]
    [Route("api/v1/controle")]
    public class ControleController : ControllerBase
    {
        readonly AppDbContext _context;
        public ControleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetControle")]
        public async Task<ActionResult<Controle>> Get()
        {
            var result = await _context.Controles.FirstOrDefaultAsync();
            if (result == null)
                return Ok(new GenericResult<Controle> {Sucesso = false, Mensagem = "Não há regstro(s)" });
            return Ok(new GenericResult<Controle> { Sucesso = true , Item = result});
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Controle controle)
        {
            _context.Add(controle);
            await _context.SaveChangesAsync();
            return new CreatedResult("GetControle", new GenericResult<Controle> {Sucesso = true, Item = controle});
        }

        [HttpPut]
        public async Task<ActionResult<Controle>> Put([FromBody] Controle controle)
        {
            _context.Entry(controle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new GenericResult<Controle> { Sucesso = true });
        }
    }
}
