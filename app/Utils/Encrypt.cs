using Microsoft.AspNetCore.Identity;
using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Utils.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Utils;

public class Encrypt : IEncrypt
{
  private readonly PasswordHasher<User> _hasher = new();

  public string Hash(string password)
  {
    return _hasher.HashPassword(null, password);
  }

  public bool Verify(string hash, string password)
  {
    var result = _hasher.VerifyHashedPassword(null, hash, password);
    return result == PasswordVerificationResult.Success;
  }
}