using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly string _key = "secret-key"; // Substitua pela chave

    //[HttpPost("login")]
    //public IActionResult Login([FromBody] UserLogin user)
    //{

    //    if (user.Username != "admin" || user.Password != "password")
    //    {
    //        return Unauthorized();
    //    }

    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var key = Encoding.ASCII.GetBytes(_key);

    //    var tokenDescriptor = new SecurityTokenDescriptor
    //    {
    //        Subject = new ClaimsIdentity(new[]
    //        {
    //            new Claim(ClaimTypes.Name, user.Username)
    //        }),
    //        Expires = DateTime.UtcNow.AddHours(1),
    //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //    };

    //    var token = tokenHandler.CreateToken(tokenDescriptor);
    //    var tokenString = tokenHandler.WriteToken(token);

    //    return Ok(new { Token = tokenString });
    //}
}

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}
