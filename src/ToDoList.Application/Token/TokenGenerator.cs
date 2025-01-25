using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDoList.API.Token;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Token;

public class TokenGenerator : ITokenGenerator
{
    
    public dynamic GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim("Email", user.Email),
            new Claim("Name", user.Name),
            new Claim("Id", user.Id.ToString())
        };
        
        var expired = DateTime.Now.AddHours(1);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dWFzZGhmcG9hc2hkZnA4MjM0LTQyMzRqaWRmaHBqc2x"));
        var tokenData = new JwtSecurityToken(
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
            claims: claims,
            expires: expired
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
        return new TokenDTO
        {
            AccessToken = token,
            Expiration = expired
        };
    }
}