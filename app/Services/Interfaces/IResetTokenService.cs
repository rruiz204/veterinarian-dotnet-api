using Veterinarian_Dotnet_Api.App.DTO;

namespace Veterinarian_Dotnet_Api.App.Services.Interfaces;

public interface IResetTokenService
{
  Task SendEmail(string email);
  Task ResetPassword(ResetPasswordDTO dto);
}