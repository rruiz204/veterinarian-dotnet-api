namespace Veterinarian_Dotnet_Api.App.Emails.Interfaces;

public interface IEmail
{
  Task Send(string to);
}