using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Veterinarian_Dotnet_Api.App.Services;

public class UserService(IUserRepository repository) : IUserService
{
  private readonly IUserRepository _repository = repository;
  private readonly PasswordHasher<User> _hasher = new();

  public async Task<User> CreateUser(User user)
  {
    user.Password = HashPassword(user, user.Password);
    return await _repository.CreateUser(user);
  }

  public string HashPassword(User user, string password)
  {
    return _hasher.HashPassword(user, password);
  }
}