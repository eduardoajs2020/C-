using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjTJurisBackend.Models
{
    public static class GeminiApi
    {
        private const string ApiKey = "YOUR_API_KEY"; // Replace with your actual API key
        private const string Endpoint = "https://vertex.ai/v1/projects/{project_id}/locations/{location}/models/{model_id}";
        private const string ProjectId = "YOUR_PROJECT_ID"; // Replace with your project ID
        private const string Location = "us-central1"; // Update if needed
        private const string ModelId = "gemini-pro"; // Update if needed

        public static async Task<string?> CallGeminiApi(string text)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestBody = new { text }; // Concise JSON object creation

                try
                {
                    var formattedEndpoint = Endpoint
                        .Replace("{project_id}", ProjectId)
                        .Replace("{location}", Location)
                        .Replace("{model_id}", ModelId);

                    var response = await client.PostAsync(formattedEndpoint,
                                                          new StringContent(JsonSerializer.Serialize(requestBody),
                                                                           Encoding.UTF8,
                                                                           "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(jsonString),
                                                         new JsonSerializerOptions { WriteIndented = true });
                    }
                    else
                    {
                        throw new Exception($"Error calling Gemini API: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return null; // Or throw a specific exception for handling
                }
            }
        }
    }
}
