using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
  private readonly IRoleRepository _roleRepository = roleRepository;

  public async Task<Role> CreateRole(Role role)
  {
    Role? existingRole = await _roleRepository.FindRoleById(role.Id);
    if (existingRole != null) throw new ArgumentException("This role already exists");
    return await _roleRepository.CreateRole(role);
  }

  public async Task<bool> DeleteRole(Role role)
  {
    Role? existingRole = await _roleRepository.FindRoleById(role.Id);
    if (existingRole == null) throw new ArgumentException("This role does not exists");
    return await _roleRepository.DeleteRole(role);
  }
}