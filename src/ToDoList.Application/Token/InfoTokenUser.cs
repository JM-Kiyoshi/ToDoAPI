using Microsoft.AspNetCore.Http;

namespace ToDoList.Application.Token;

public class InfoTokenUser : IInfoTokenUser
{
    public InfoTokenUser(IHttpContextAccessor httpContextAccessor)
    {
        var httpContext = httpContextAccessor.HttpContext;
        var claims = httpContext.User.Claims;

        if (claims.Any(x => x.Type == "Id"))
        {
            var id = Convert.ToInt64(claims.FirstOrDefault(x => x.Type == "Id").Value);
            Id = id;
        }

        if (claims.Any(x => x.Type == "Name"))
        {
            var name = claims.FirstOrDefault(x => x.Type == "Name").Value;
            Name = name;
        }
        
        if (claims.Any(x => x.Type == "Email"))
        {
            var email = claims.FirstOrDefault(x => x.Type == "Email").Value;
            Email = email;
        }
    }
    
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}