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
    
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly Context _context;

        public EnderecosController(Context context)
        {
            _context = context;
        }

        [Route("api/Enderecos/[controller]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CEP>>> Enderecos()
        {
            return await _context.CEPS.ToListAsync();
        }
        [Route("api/Enderecos/[controller]/{cep}")]
        [HttpGet("{cep}")]
        public CEP Enderecos(string cep)
        {
            return _context.CEPS.Where(e => e.Cep == cep).FirstOrDefault();
        }

        [Route("api/Enderecos/EnderecosPorEstado/{uf}")]
        [HttpGet("{uf}")]
        public ActionResult<IEnumerable<CEP>> EnderecosPorEstado(string uf)
        {
            return _context.CEPS.Where(e => e.Uf == uf).ToList();
        }
    }
}
