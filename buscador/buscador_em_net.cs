using System;
using System.Net.Http;
using HtmlAgilityPack;

namespace WebScraperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // URL da página de pesquisa do TJMG
            string url = "http://www.tjmg.jus.br/consultas/jurisprudencia/pesquisa";

            // Termo de pesquisa
            string termoPesquisa = "exemplo de pesquisa";

            // Realiza a pesquisa e obtém o HTML da página de resultados
            string htmlContent = PesquisarNoSiteTJMG(url, termoPesquisa);

            // Extrai os títulos dos links dos resultados da pesquisa
            ExtrairTitulosDosLinks(htmlContent);

            Console.ReadKey();
        }

        static string PesquisarNoSiteTJMG(string url, string termoPesquisa)
        {
            using (var httpClient = new HttpClient())
            {
                // Parâmetros da pesquisa (no exemplo, estou usando GET)
                string parametros = $"?q={termoPesquisa}";

                // Monta a URL completa da pesquisa
                string pesquisaUrl = $"{url}{parametros}";

                // Obtém o conteúdo HTML da página de resultados
                var response = httpClient.GetStringAsync(pesquisaUrl).Result;
                return response;
            }
        }

        static void ExtrairTitulosDosLinks(string htmlContent)
        {
            // Criando um objeto HtmlDocument para analisar o conteúdo HTML
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlContent);

            // Usa XPath para selecionar os títulos dos links nos resultados da pesquisa
            var titulosLinks = htmlDocument.DocumentNode.SelectNodes("//h3[@class='titulo_pesquisa']/a");

            // Verifica se foram encontrados resultados
            if (titulosLinks != null)
            {
                Console.WriteLine("Resultados da pesquisa:");
                foreach (var tituloLink in titulosLinks)
                {
                    Console.WriteLine(tituloLink.InnerText);
                    Console.WriteLine(tituloLink.GetAttributeValue("href", ""));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nenhum resultado encontrado.");
            }
        }
    }
}
