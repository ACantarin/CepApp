using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CepApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.Models;

namespace CepApp.Controllers.Endereco
{
    [Route("api/Enderecos/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly Context _context;

        public EnderecosController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CEP>>> Enderecos()
        {
            return await _context.CEPS.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CEP>> Enderecos(int id)
        {
            var endereco = await _context.CEPS.FindAsync(id);
            return endereco;
        }
    }
}
