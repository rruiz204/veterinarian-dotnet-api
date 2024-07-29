using Veterinarian_Dotnet_Api.App.DTO;
using Veterinarian_Dotnet_Api.App.Models;

namespace Veterinarian_Dotnet_Api.App.Services.Interfaces;

public interface IUserService
{
  Task<User> CreateUser(User user);
  Task<User> LoginUser(LoginDTO user);
}