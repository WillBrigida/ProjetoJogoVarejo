using JogoVarejo.Data;
using JogoVarejo.Shared.Models;
using JogoVarejo.Shared.Models.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace JogoVarejo.Server.Controllers
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
            try
            {
                var result = await _context.Controle.FirstOrDefaultAsync();
                if (result == null)
                    return Ok(new GenericResult<Controle> { Sucesso = false, Mensagem = "Não há regstro(s)" });
                return Ok(new GenericResult<Controle> { Sucesso = true, Item = result });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Controle> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Controle controle)
        {
            try
            {
                _context.Add(controle);
                await _context.SaveChangesAsync();
                return new CreatedResult("GetControle", new GenericResult<Controle> { Sucesso = true, Item = controle });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Controle> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }
        }

        [HttpPut]
        public async Task<ActionResult<Controle>> Put([FromBody] Controle controle)
        {
            try
            {
                _context.Entry(controle).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new GenericResult<Controle> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Controle> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }
        }
    }
}
