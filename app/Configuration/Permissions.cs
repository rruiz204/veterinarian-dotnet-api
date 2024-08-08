namespace Veterinarian_Dotnet_Api.App.Configuration;

public static class Permissions
{
  public static void AddAuthorizationPolicies(this IServiceCollection services)
  {
    services.AddAuthorizationBuilder()
      .AddPolicy("TestPermission", policy => policy.RequireRole("Admin"));
  }
}