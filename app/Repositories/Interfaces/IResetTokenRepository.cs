using Veterinarian_Dotnet_Api.App.Models;

namespace Veterinarian_Dotnet_Api.App.Repositories.Interfaces;

public interface IResetTokenRepository
{
  Task<ResetToken> CreateResetToken(ResetToken token);
  Task DeleteResetToken(ResetToken token);
  Task<ResetToken?> FindValidToken(string token);
}