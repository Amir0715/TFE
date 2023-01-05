using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TFE.Domain.Interfaces;

namespace TFE.Infrastructure.Identity;

public class IdentityTokenClaimService : ITokenClaimsService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtOptions _jwtOptions;

    public IdentityTokenClaimService(UserManager<ApplicationUser> userManager, IOptions<JwtOptions> jwtOptions)
    {
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<string> GetTokenAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        var roles = await _userManager.GetRolesAsync(user);
        
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Name, userName), 
            new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new (JwtRegisteredClaimNames.Email, user.Email),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        // var key = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);
        var key = "9C9482B98D985AF5DB915CE4573A8"u8.ToArray();
        var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            //Issuer = _jwtOptions.Issuer,
            Issuer = "TFE",
            IssuedAt = DateTime.UtcNow,
            //Audience = _jwtOptions.Audience,
            Audience = "TFE",
            SigningCredentials = signinCredentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        return jwtToken;
    }
}