using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TjurisNew.Models;

namespace TjurisNew.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TjurisNewController : ControllerBase
    {
        private static readonly List<Processos> processos = new List<Processos>();

        [HttpPost("abrir")]
        public IActionResult AbrirProcesso([FromBody] Processos processo)
        {
            if (processo == null || string.IsNullOrEmpty(processo.Assunto) || string.IsNullOrEmpty(processo.Descricao))
            {
                return BadRequest("Os campos 'assunto' e 'descricao' são obrigatórios.");
            }


            processos.Add(processo);
            processo.Status = "Aberto";
            return Ok($"Chamado {processo.Numero} aberto com sucesso.");

        }

        [HttpPost("fechar/{numero}")]
        public IActionResult FecharProcesso(int numero)
        {
            var processo = processos.Find(p => p.Numero == numero);
            if (processo != null)
            {
                processo.DataFechamento = DateTime.Now;
                processo.Status = "Fechado";
                return Ok($"Processo {processo.Numero} fechado com sucesso.");
            }
            else
            {
                return NotFound($"Processo {numero} não encontrado.");
            }
        }

        [HttpGet("listar")]
        public IActionResult ListarProcessos()
        {
            var processosAbertos = processos.Where(p => p.Status == "Aberto").ToList();
            var processosFechados = processos.Where(p => p.Status == "Fechado").ToList();

            return Ok(new
            {
                ProcessosAbertos = processosAbertos,
                ProcessosFechados = processosFechados
            });
        }

    }


}