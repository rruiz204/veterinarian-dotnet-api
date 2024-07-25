using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;
using Veterinarian_Dotnet_Api.App.Utils.Interfaces;
using Veterinarian_Dotnet_Api.App.Exceptions;

namespace Veterinarian_Dotnet_Api.App.Services;

public class UserService(IUserRepository repository, IEncryptPassword encrypt) : IUserService
{
  private readonly IUserRepository _repository = repository;
  private readonly IEncryptPassword _encrypt = encrypt;

  public async Task<User> CreateUser(User user)
  {
    User? existing = await _repository.FindUserByEmail(user.Email);
    if (existing != null) throw new EmailAlreadyExistsException();

    user.Password = _encrypt.Hash(user.Password);
    return await _repository.CreateUser(user);
  }
}