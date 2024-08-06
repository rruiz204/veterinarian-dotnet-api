using System.ComponentModel.DataAnnotations;

namespace Veterinarian_Dotnet_Api.App.Models;

public class ResetToken
{
  [Key]
  public int Id { get; set; }

  [Required]
  [EmailAddress]
  [MaxLength(150)]
  public required string Email { get; set; }

  [Required]
  public required string Token { get; set; }

  [Required]
  public required DateTime Expiration { get; set; }
}