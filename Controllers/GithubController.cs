using Microsoft.AspNetCore.Mvc;
using ApiGithub.Models;
using Microsoft.AspNetCore.Authorization;



[ApiController]
[Route("api/[controller]")]

[ProducesResponseType(200)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class GithubController : ControllerBase
{
    private readonly GithubService _githubService;

    public GithubController(GithubService gitHubService)
    {
        _githubService = gitHubService;
    }


    /// <summary>
    /// Busca as principais informações de um repositório
    /// </summary>
    [HttpGet("{userName}")]
    //[Authorize]
    public async Task<ActionResult<List<Repository>>> GetRepositories(string userName)
    {
        try
        {
            var repositories = await _githubService.GetPublicRepositories(userName);
            return Ok(repositories);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Busca informações de um repositório específico 
    /// </summary>
    [HttpGet("{owner}/{repo}")]
    //[Authorize]
    public async Task<ActionResult<Repository>> GetRepositoryDetails(string owner, string repo)
    {
        try
        {
            var repository = await _githubService.GetRepositoryDetails(owner, repo);
            return Ok(repository);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Obtém a url do avatar do usuário
    /// </summary>
    [HttpGet("avatar/{userName}")]
    //[Authorize]
    public async Task<ActionResult<string>> GetUserAvatar(string userName)
    {
        try
        {
            var avatarUrl = await _githubService.GetUserAvatar(userName);
            return Ok(new { avatarUrl });
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

}

