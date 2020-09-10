//using JogoVarejo.Data;
//using JogoVarejo.Shared.Models;
//using JogoVarejo.Shared.Models.Utils;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Threading.Tasks;

//namespace JogoVarejo.Server.Controllers
//{
//    [ApiController]
//    [Route("api/v1/controle")]
//    public class ControleController : ControllerBase
//    {
//        readonly AppDbContext _context;
//        public ControleController(AppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet(Name = "GetControle")]
//        public async Task<ActionResult<Controle>> Get()
//        {
//            try
//            {
//                var controle = await _context.T_controle.FirstOrDefaultAsync();
//                if (controle == null)
//                    return Ok(new GenericResult<Controle> { Sucesso = false, MensagemErro = "Não há registros no Banco de dados" });
//                return Ok(new GenericResult<Controle> { Sucesso = true, Item = controle });
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                return BadRequest(new GenericResult<Controle> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
//            }
//        }


//        [HttpPost]
//        public async Task<ActionResult> Post([FromBody] Controle controle)
//        {
//            try
//            {
//                await _context.AddAsync(controle);
//                await _context.SaveChangesAsync();
//                return new CreatedResult("GetControle", new GenericResult<Controle> { Sucesso = true, Item = controle });
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                return BadRequest(new GenericResult<Controle> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
//            }
//        }

//        [HttpPut]
//        public async Task<ActionResult<Controle>> Put([FromBody] Controle controle)
//        {
//            try
//            {
//                _context.Entry(controle).State = EntityState.Modified;
//                await _context.SaveChangesAsync();
//                return Ok(new GenericResult<Controle> { Sucesso = true });
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                return BadRequest(new GenericResult<Controle> { Sucesso = false, MensagemErro = "Não foi possível atender essa requisição. Tente novamente." });
//            }

//        }
//    }
//}
