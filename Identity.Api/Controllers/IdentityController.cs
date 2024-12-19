using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
public class IdentityController : ControllerBase
{
    private const string TokenSecret = "SuperImpressiveSecurityKey";
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(4);
    
    [HttpPost("token")]
    public IActionResult GenerateToken([FromBody] TokenRequestDto request)
    {
        if (request.Username == "admin" && request.Password == "admin")
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, request.Username)
                }),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new { Token = tokenString });
        }
        return Unauthorized();
    }
}