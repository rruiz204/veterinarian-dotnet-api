using Veterinarian_Dotnet_Api.App.DTO;
using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Utils.Interfaces;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Services;

public class ResetTokenService(
  IResetTokenRepository resetTokenRepository,
  IUserRepository userRepository,
  IEncrypt encrypt
) : IResetTokenService
{
  private readonly IResetTokenRepository _resetTokenRepository = resetTokenRepository;
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IEncrypt _encrypt = encrypt;

  public async Task SendEmail(string email)
  {
    User? user = await _userRepository.FindUserByEmail(email);
    if (user == null) throw new ArgumentException("This user does not exist");

    string guid = Guid.NewGuid().ToString();
    ResetToken token = new()
    {
      Email = email,
      Token = guid,
      Expiration = DateTime.UtcNow.AddHours(1)
    };

    await _resetTokenRepository.CreateResetToken(token);
  }

  public async Task ResetPassword(ResetPasswordDTO dto)
  {
    ResetToken? resetToken = await _resetTokenRepository.FindValidToken(dto.Token);
    if (resetToken == null) throw new ArgumentException("Invalid or expired token");

    User? user = await _userRepository.FindUserByEmail(resetToken.Email);
    if (user == null) throw new ArgumentException("This user does not exist");

    user.Password = _encrypt.Hash(dto.Password);
    await _userRepository.UpdateUser(user);
    await _resetTokenRepository.DeleteResetToken(resetToken);
  }
}