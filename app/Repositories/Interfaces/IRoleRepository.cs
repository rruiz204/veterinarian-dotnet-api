using Veterinarian_Dotnet_Api.App.Models;

namespace Veterinarian_Dotnet_Api.App.Repositories.Interfaces;

public interface IRoleRepository
{
  Task<Role> CreateRole(Role role);
  Task<bool> DeleteRole(Role role);
  Task<Role?> FindRoleById(int id);
}