namespace Veterinarian_Dotnet_Api.App.Configuration;

public class Mailtrap
{
    public required string Host { get; set; }
    public int Port { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}