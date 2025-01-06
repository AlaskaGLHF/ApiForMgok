using ApiForMgok.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiForMgok.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    private readonly ApiForMgokContext _context;

    // Внедряем ApiForMgokContext через конструктор
    public TokenService(IConfiguration config, ApiForMgokContext context)
    {
        _config = config;
        _context = context;

        var signinKey = _config["JWT:SigninKey"];
        if (string.IsNullOrEmpty(signinKey))
        {
            throw new InvalidOperationException("JWT:SigninKey is not configured in appsettings.json");
        }

        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
    }

    public string CreateToken(Employee employee)
    {
        string roleName = _context.Roles
            .Where(role => role.Id == employee.RoleId)
            .Select(role => role.Name)
            .FirstOrDefault() ?? "User";  // "User" используется как значение по умолчанию

        // Создаем список claim
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, employee.Email),
            new Claim(ClaimTypes.GivenName, employee.FullName),
            new Claim(ClaimTypes.Role, roleName)
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"],
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(5),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
