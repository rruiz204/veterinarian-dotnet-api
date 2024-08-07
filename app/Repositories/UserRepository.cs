using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Database;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Veterinarian_Dotnet_Api.App.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
  private readonly DatabaseContext _context = context;

  public async Task<User?> FindUserByEmail(string email)
  {
    return await _context.User.FirstOrDefaultAsync(user => user.Email == email);
  }

  public async Task<User> CreateUser(User user)
  {
    await _context.User.AddAsync(user);
    await _context.SaveChangesAsync();
    return user;
  }

  public async Task<User> UpdateUser(User user)
  {
    _context.User.Update(user);
    await _context.SaveChangesAsync();
    return user;
  }
}