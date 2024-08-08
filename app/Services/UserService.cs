using Veterinarian_Dotnet_Api.App.DTO;
using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Utils.Interfaces;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Services;

public class UserService(IUserRepository repository, IEncrypt encrypt) : IUserService
{
  private readonly IUserRepository _repository = repository;
  private readonly IEncrypt _encrypt = encrypt;

  public async Task<User> CreateUser(User user)
  {
    User? existing = await _repository.FindUserByEmail(user.Email);
    if (existing != null) throw new ArgumentException("This email already exists");

    user.Password = _encrypt.Hash(user.Password);
    return await _repository.CreateUser(user);
  }

  public async Task<User> LoginUser(LoginDTO dto)
  {
    User? existing = await _repository.FindUserByEmail(dto.Email);
    if (existing == null) throw new ArgumentException("This user does not exist");

    if (!_encrypt.Verify(existing.Password, dto.Password)) throw new ArgumentException("Invalid Credentials");
    return existing;
  }
}