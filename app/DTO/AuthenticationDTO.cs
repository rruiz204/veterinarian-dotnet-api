namespace Veterinarian_Dotnet_Api.App.DTO;

public class AuthenticationDTO(string token)
{
  public string Type { get; set; } = "Bearer";
  public string Token { get; set; } = token;
}