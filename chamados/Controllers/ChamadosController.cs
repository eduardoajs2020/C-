using Microsoft.AspNetCore.Mvc;
using SistemaGestaoChamados.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SistemaGestaoChamados.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class ChamadosController : ControllerBase
    {
        
        private static readonly List<Chamado> chamados = new List<Chamado>();
        
        [HttpPost("abrir")]
        public IActionResult AbrirChamado([FromBody] Chamado chamado)
        {
            if (chamado == null || string.IsNullOrEmpty(chamado.Assunto) || string.IsNullOrEmpty(chamado.Descricao))
            {
                return BadRequest("Os campos 'assunto' e 'descricao' são obrigatórios.");
            }

           
            chamados.Add(chamado);
            chamado.Status = "Aberto";
            return Ok($"Chamado {chamado.Numero} aberto com sucesso.");
        }

        [HttpPost("fechar/{numero}")]
        public IActionResult FecharChamado(int numero)
        {
            var chamado = chamados.Find(c => c.Numero == numero);
            if (chamado != null)
            {
                chamado.DataFechamento = DateTime.Now;
                chamado.Status = "Fechado";
                return Ok($"Chamado {chamado.Numero} fechado com sucesso.");
            }
            else
            {
                return NotFound($"Chamado {numero} não encontrado.");
            }
        }

        [HttpGet("listar")]
        public IActionResult ListarChamados()
        {
            var chamadosAbertos = chamados.Where(c => c.Status == "Aberto").ToList();
            var chamadosFechados = chamados.Where(c => c.Status == "Fechado").ToList();

            return Ok(new
            {
                ChamadosAbertos = chamadosAbertos,
                ChamadosFechados = chamadosFechados
            });
        }
    }

    
}