using System.ComponentModel.DataAnnotations;

namespace Veterinarian_Dotnet_Api.App.Models;

public class User
{
  [Key]
  public int Id { get; set; }

  [Required]
  [StringLength(50)]
  public required string FirstName { get; set; }

  [Required]
  [StringLength(50)]
  public required string LastName { get; set; }

  [Required]
  [EmailAddress]
  [MaxLength(150)]
  public required string Email { get; set; }

  [Required]
  [MinLength(8)]
  public required string Password { get; set; }

  [Required]
  [Phone]
  [StringLength(9)]
  public required string PhoneNumber { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}