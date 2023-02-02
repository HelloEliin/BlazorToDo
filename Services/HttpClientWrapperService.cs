using BlazorAppz.Data;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BlazorAppz.Services
{
    public class HttpClientWrapperService
    {

        private readonly string _baseUrl =  $"https://localhost:7178/api/";
        public HttpClient _httpClient;

        public HttpClientWrapperService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<T> Get<T>(string url)
        {
            var response = await _httpClient.GetAsync(_baseUrl+url);
            response.EnsureSuccessStatusCode();
           using var responseContent = await response.Content.ReadAsStreamAsync();
           return await JsonSerializer.DeserializeAsync<T>(responseContent);    
        }

        public async Task<T> PutAsync<T>(string url, HttpContent content)
        {
            var response = await _httpClient.PutAsync(_baseUrl+url, content);
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseContent);
        }

        public async Task<T> PostAsync<T>(string url, HttpContent content)
        {
            var response = await _httpClient.PostAsync(_baseUrl + url, content);
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseContent);
        }

        public async Task<T> DeleteAsync<T>(string url)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + url);
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseContent);
        }



    }
}
