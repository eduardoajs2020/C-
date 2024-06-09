using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjTJurisBackend.Models
{
    public class Processo
    {
        public int Numero { get; set; }

        public required string Assunto { get; set; }
        public required string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string? Status { get; set; }

    }
}