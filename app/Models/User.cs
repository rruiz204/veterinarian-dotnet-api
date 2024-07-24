using System.ComponentModel.DataAnnotations;

namespace Veterinarian_Dotnet_Api.App.Models;

public class User
{
  [Key]
  public int Id { get; set; }

  [Required]
  [EmailAddress]
  [MaxLength(150)]
  public required string Email { get; set; }

  [Required]
  [MinLength(8)]
  public required string Password { get; set; }
  
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}