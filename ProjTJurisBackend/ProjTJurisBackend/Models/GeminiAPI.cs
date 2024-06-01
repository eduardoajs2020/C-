using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProjTJurisBackend.Models
{
    public static class GeminiApi
    {
        static void Main(string[] args)
        {
            // Defina a chave da API e o endpoint da API
            string apiKey = "SEU_CHAVE_DE_API";
            string endpoint = "https://vertex.ai/v1/projects/{project_id}/locations/{location}/models/{model_id}";

            // Substitua {project_id}, {location} e {model_id} pelos seus valores reais
            string projectId = "SEU_ID_DO_PROJETO";
            string location = "us-central1";
            string modelId = "gemini-pro";

            // Crie um objeto HttpClient para fazer solicitações HTTP
            HttpClient client = new HttpClient();

            // Adicione a chave da API ao cabeçalho da solicitação
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            // Crie o corpo da solicitação JSON
            string requestBody = "{ \"text\": \"Olá, mundo 2!\" }";

            // Defina o tipo de conteúdo da solicitação como JSON
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Envie a solicitação POST para o endpoint da API
            HttpResponseMessage response = client.PostAsync(endpoint.Replace("{project_id}", projectId).Replace("{location}", location).Replace("{model_id}", modelId), new StringContent(requestBody)).Result;

            // Verifique se a solicitação foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                // Leia a resposta JSON
                string jsonString = response.Content.ReadAsStringAsync().Result;

                // Deserialize a resposta JSON em um objeto dinâmico
                dynamic jsonData = JsonSerializer.Deserialize<object>(jsonString);

                // Imprima a resposta JSON formatada
                Console.WriteLine(JsonSerializer.Serialize(jsonData, new JsonSerializerOptions { WriteIndented = true }));
            }
            else
            {
                Console.WriteLine("Erro ao chamar a API do Gemini: " + response.StatusCode);
            }
        }
    }


}
