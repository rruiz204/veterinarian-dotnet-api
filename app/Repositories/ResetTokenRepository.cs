using Microsoft.EntityFrameworkCore;
using Veterinarian_Dotnet_Api.App.Database;
using Veterinarian_Dotnet_Api.App.Models;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Repositories;

public class ResetTokenRepository(DatabaseContext context) : IResetTokenRepository
{
  private readonly DatabaseContext _context = context;

  public async Task<ResetToken?> FindValidToken(string token)
  {
    return await _context.ResetToken.FirstOrDefaultAsync(t => t.Token == token && t.Expiration > DateTime.UtcNow);
  }

  public async Task<ResetToken> CreateResetToken(ResetToken token)
  {
    await _context.ResetToken.AddAsync(token);
    await _context.SaveChangesAsync();
    return token;
  }

  public async Task DeleteResetToken(ResetToken token)
  {
    _context.ResetToken.Remove(token);
    await _context.SaveChangesAsync();
  }
}