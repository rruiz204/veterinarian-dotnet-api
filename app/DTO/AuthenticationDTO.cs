namespace Veterinarian_Dotnet_Api.App.DTO;

public class AuthResponseDTO(string token)
{
  public string Type { get; set; } = "Bearer";
  public string Token { get; set; } = token;
}

public class LoginDTO()
{
  public required string Email { get; set; }
  public required string Password { get; set; }
}

public class ResetPasswordDTO()
{
  public required string Token { get; set; }
  public required string Password { get; set; }
}