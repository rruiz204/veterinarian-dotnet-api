using Veterinarian_Dotnet_Api.App.Models;

namespace Veterinarian_Dotnet_Api.App.Services.Interfaces;

public interface IRoleService
{
  Task<Role> CreateRole(Role role);
  Task<bool> DeleteRole(Role role);
}