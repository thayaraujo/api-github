using Microsoft.AspNetCore.Mvc;
using ApiGithub.Models;
using Microsoft.AspNetCore.Authorization;



[ApiController]
[Route("api/[controller]")]
public class GithubController : ControllerBase
{
    private readonly GithubService _githubService;

    public GithubController(GithubService gitHubService)
    {
        _githubService = gitHubService;
    }



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

