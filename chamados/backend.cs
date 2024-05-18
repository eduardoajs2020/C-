csharp

using System;
using System.Collections.Generic;

namespace SistemaGestaoChamados
{
    public class Chamado
    {
        public int Numero { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string Status { get; set; }

        public Chamado(int numero, string assunto, string descricao)
        {
            Numero = numero;
            Assunto = assunto;
            Descricao = descricao;
            DataAbertura = DateTime.Now;
            Status = "Aberto";
        }
    }

    public class SistemaGestaoChamados
    {
        private List<Chamado> chamados;

        public SistemaGestaoChamados()
        {
            chamados = new List<Chamado>();
        }

        public void AbrirChamado(int numero, string assunto, string descricao)
        {
            Chamado chamado = new Chamado(numero, assunto, descricao);
            chamados.Add(chamado);
            Console.WriteLine($"Chamado {chamado.Numero} aberto com sucesso.");
        }

        public void FecharChamado(int numero)
        {
            Chamado chamado = chamados.Find(c => c.Numero == numero);
            if (chamado != null)
            {
                chamado.DataFechamento = DateTime.Now;
                chamado.Status = "Fechado";
                Console.WriteLine($"Chamado {chamado.Numero} fechado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Chamado {numero} não encontrado.");
            }
        }

        public void ListarChamados()
        {
            Console.WriteLine("Chamados Abertos:");
            foreach (Chamado chamado in chamados)
            {
                if (chamado.Status == "Aberto")
                {
                    Console.WriteLine($"Número: {chamado.Numero}, Assunto: {chamado.Assunto}, Data Abertura: {chamado.DataAbertura}");
                }
            }

            Console.WriteLine("\nChamados Fechados:");
            foreach (Chamado chamado in chamados)
            {
                if (chamado.Status == "Fechado")
                {
                    Console.WriteLine($"Número: {chamado.Numero}, Assunto: {chamado.Assunto}, Data Abertura: {chamado.DataAbertura}, Data Fechamento: {chamado.DataFechamento}");
                }
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            SistemaGestaoChamados sistema = new SistemaGestaoChamados();

            sistema.AbrirChamado(1, "Problema no sistema", "O sistema está apresentando um erro ao salvar os dados.");
            sistema.AbrirChamado(2, "Solicitação de suporte", "É necessário configurar um novo usuário no sistema.");
            sistema.AbrirChamado(3, "Falha no servidor", "O servidor está inacessível.");

            sistema.FecharChamado(2);

            sistema.ListarChamados();

            Console.ReadLine();
        }
    }
}
