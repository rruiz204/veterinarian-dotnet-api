using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Veterinarian_Dotnet_Api.App.Utils.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Utils;

public class Tokens(IConfiguration configuration) : ITokens
{
  private readonly IConfiguration _configuration = configuration;

  public string Generate(int id)
  {
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var claims = new[] {
      new Claim(JwtRegisteredClaimNames.Sub, id.ToString())
    };

    var token = new JwtSecurityToken(
      issuer: _configuration["JWT:Issuer"],
      audience: _configuration["JWT:Audience"],
      claims: claims,
      expires: DateTime.Now.AddHours(1),
      signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}