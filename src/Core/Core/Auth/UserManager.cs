using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Auth;

public class UserManager(IConfiguration configuration) : IUserManager
{

    private static readonly List<UserRoles> UserRoles =
    [
        new UserRoles{ Name = "Admin", Id = 1}
    ];


    private readonly List<User> _users =
    [
        new User{ UserName = "Admin", Password = "12345"}
    ];

    public string Login(User user)
    {
        var loginUser = _users.SingleOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

        if (loginUser == null)
        {
            return string.Empty;
        }


        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        authClaims.AddRange(UserRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole.Name)));

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Secret"]!));

        var token = new JwtSecurityToken(
            issuer: configuration["Authentication:ValidIssuer"],
            audience: configuration["Authentication:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}