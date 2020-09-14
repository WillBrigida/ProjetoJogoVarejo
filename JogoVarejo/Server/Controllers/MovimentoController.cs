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
    [Route("api/v1/movimento")]
    public class MovimentoController : ControllerBase
    {
        readonly AppDbContext _context;
        public MovimentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("procedure")]
        public async Task<ActionResult<List<VwMovimentos>>> Procedure(Grupos grupo)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC spInserirNovoDia {0}", grupo.GrupoId);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<VwMovimentos> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<VwMovimentos>>> GetMovimentosById(int id)
        {
            try
            {
                var movimentos = await _context.VwMovimentos
                    .Where(x => x.GrupoId == id)
                    .ToListAsync();
                return Ok(new GenericResult<VwMovimentos> { Sucesso = true, Items = movimentos });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<VwMovimentos> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }
        }


        [HttpGet("indicadores/{id}")]
        public async Task<ActionResult<List<VwIndicadores>>> GetIndicadoresById(int id)
        {
            try
            {
                var indicadores = await _context.VwIndicadores
                    .Where(x => x.GrupoId == id)
                    .FirstOrDefaultAsync();

                return Ok(new GenericResult<VwIndicadores> { Sucesso = true, Item = indicadores });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<VwIndicadores> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }
        }

        [HttpPut]
        public async Task<ActionResult<Movimentos>> DeleteById([FromBody] VwMovimentos movimentos)
        {
            var movi = new Movimentos
            {
                Areceber = movimentos.Areceber,
                Comprado = movimentos.Comprado,
                Demanda = movimentos.Demanda,
                Dia = movimentos.Dia,
                GrupoId = movimentos.GrupoId,
                MovimentoId = movimentos.MovimentoId,
                Prazo = movimentos.Prazo,
                Recebido = movimentos.Recebido,
                SaldoFinal = movimentos.SaldoFinal,
                SaldoInicial = movimentos.SaldoInicial,
                SaldoMedioDia = movimentos.SaldoMedioDia,
                Vendido = movimentos.Vendido
            };

            try
            {
                _context.Movimentos.Update(movi);
                await _context.SaveChangesAsync();

                return Ok(new GenericResult<Movimentos> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Movimentos> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Movimentos>> DeleteById(int id)
        {
            try
            {
                var mov = await _context.Movimentos.SingleAsync(x => x.MovimentoId == id);
                _context.Movimentos.Remove(mov);
                await _context.SaveChangesAsync();

                return Ok(new GenericResult<Movimentos> { Sucesso = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResult<Movimentos> { Sucesso = false, Mensagem = "Não foi possível atender essa solicitação. Tente novamente." });
            }
        }
    }
}