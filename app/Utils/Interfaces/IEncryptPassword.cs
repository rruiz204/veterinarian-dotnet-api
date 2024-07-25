using Veterinarian_Dotnet_Api.App.Models;

namespace Veterinarian_Dotnet_Api.App.Utils.Interfaces;

public interface IEncryptPassword
{
  string Hash(string password);
  bool Verify(string hash, string password);
}