//using JogoVarejo_Server.Server.Data;
//using JogoVarejo_Server.Shared.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;

//namespace JogoVarejo_Server.Server.Controllers
//{
//    [ApiController]
//    [Route("api/v1/[controller]")]
//    public class ControleController : ControllerBase
//    {
//        readonly AppDbContext _context;
//        public ControleController(AppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet("con", Name = "GetControle")]
//        public async Task<ActionResult<Controle>> Get()
//        {
//            return await _context.T_controle2.FirstOrDefaultAsync(x => x.ControleId == 1);
//        }

//        [HttpPost("contr")]
//        public async Task<ActionResult> Post([FromForm] Controle controle)
//       {
//        //    if (_context.T_controle.ToList().Any())
//        //    {
//        //        _context.Entry(controle).State = EntityState.Modified;
//        //        await _context.SaveChangesAsync();
//        //    }

//        //    else

//            _context.Add(controle);
//            await _context.SaveChangesAsync();
//            //return new CreatedAtRouteResult("GetControle", new { id = controle.ControleId }, controle);

          
//            return Ok(controle);
//        }

//        [HttpPut]
//        public async Task<ActionResult<Controle>> Put(Controle controle)
//        {
//            _context.Entry(controle).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//            return Ok(controle);
//        }
//    }
//}
