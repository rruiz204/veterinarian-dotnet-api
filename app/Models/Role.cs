using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinarian_Dotnet_Api.App.Models;

public class Role
{
  [Key]
  public int Id { get; set; }

  [Required]
  public required string Name { get; set; }

  public ICollection<UserRole> UserRoles { get; set; }
}