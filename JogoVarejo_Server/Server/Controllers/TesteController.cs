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
    [Route("api/v1/controle")]
    public class TesteController : ControllerBase
    {
        readonly AppDbContext _context;
        public TesteController(AppDbContext context)
        {
            _context = context;
        }
    }
}
