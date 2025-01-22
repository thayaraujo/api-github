using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ApiGithub.Models;


public class GithubService
{
    private readonly HttpClient _httpClient;

    public GithubService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Repository>> GetPublicRepositories(string userName)
    {
        var response = await _httpClient.GetAsync($"https://api.github.com/users/{userName}/repos");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Repository>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<Repository> GetRepositoryDetails(string owner, string repo)
    {
        var response = await _httpClient.GetAsync($"https://api.github.com/repos/{owner}/{repo}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Repository>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<string> GetUserAvatar(string userName)
    {
        var response = await _httpClient.GetAsync($"https://api.github.com/users/{userName}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var user = JsonSerializer.Deserialize<JsonElement>(json);

        // Retorna a URL do avatar
        return user.GetProperty("avatar_url").GetString();
    }





}
