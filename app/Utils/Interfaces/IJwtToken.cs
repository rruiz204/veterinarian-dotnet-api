namespace Veterinarian_Dotnet_Api.App.Utils.Interfaces;

public interface IJwtToken
{
  string Generate(int id);
}