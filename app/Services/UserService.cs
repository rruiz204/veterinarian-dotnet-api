using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;
using Veterinarian_Dotnet_Api.App.Utils.Interfaces;
using Veterinarian_Dotnet_Api.App.Emails.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Services;

public class UserService(IUserRepository repository, IEncryptPassword encrypt, IEmail mail) : IUserService
{
  private readonly IUserRepository _repository = repository;
  private readonly IEncryptPassword _encrypt = encrypt;
  private readonly IEmail _mail = mail;

  public async Task<User> CreateUser(User user)
  {
    User? existing = await _repository.FindUserByEmail(user.Email);
    if (existing != null) throw new ArgumentException("This email already exists");

    user.Password = _encrypt.Hash(user.Password);
    await _mail.Send(user.Email);
    return await _repository.CreateUser(user);
  }

  public async Task<User> LoginUser(User user)
  {
    User? existing = await _repository.FindUserByEmail(user.Email);
    if (existing == null) throw new ArgumentException("This user does not exist");

    if (!_encrypt.Verify(existing.Password, user.Password)) throw new ArgumentException("Invalid Credentials");
    return existing;
  }
}