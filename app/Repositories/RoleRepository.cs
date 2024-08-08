using Veterinarian_Dotnet_Api.App.Database;
using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Repositories;

public class RoleRepository(DatabaseContext context) : IRoleRepository
{
  private readonly DatabaseContext _context = context;

  public async Task<Role> CreateRole(Role role)
  {
    await _context.Role.AddAsync(role);
    await _context.SaveChangesAsync();
    return role;
  }

  public async Task<bool> DeleteRole(Role role)
  {
    _context.Role.Remove(role);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<Role?> FindRoleById(int id)
  {
    return await _context.Role.FindAsync(id);
  }
}