namespace Veterinarian_Dotnet_Api.App.Exceptions;

public class EmailAlreadyExistsException : Exception
{
  public EmailAlreadyExistsException() : base("This email already exists") {}
}