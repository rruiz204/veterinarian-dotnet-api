using Veterinarian_Dotnet_Api.App.Models;

namespace Veterinarian_Dotnet_Api.App.Repositories.Interfaces;

public interface IUserRepository
{
  Task<User?> FindUserByEmail(string email);
  Task<User> CreateUser(User user);
}