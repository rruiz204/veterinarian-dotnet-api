// Services and Repositories
using Veterinarian_Dotnet_Api.App.Services;
using Veterinarian_Dotnet_Api.App.Services.Interfaces;

using Veterinarian_Dotnet_Api.App.Repositories;
using Veterinarian_Dotnet_Api.App.Repositories.Interfaces;

// Utilities
using Veterinarian_Dotnet_Api.App.Utils;
using Veterinarian_Dotnet_Api.App.Utils.Interfaces;

// Database
using Microsoft.EntityFrameworkCore;
using Veterinarian_Dotnet_Api.App.Database;

// JWT Authentication
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// Configurations
using Veterinarian_Dotnet_Api.App.Configuration;

// Mailing
using Veterinarian_Dotnet_Api.App.Emails;
using Veterinarian_Dotnet_Api.App.Emails.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllers
builder.Services.AddControllers();

// Database Context
builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
        };
    });

// Services and Repositories
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IResetTokenService, ResetTokenService>();
builder.Services.AddScoped<IResetTokenRepository, ResetTokenRepository>();

// Utilities
builder.Services.AddScoped<IEncrypt, Encrypt>();
builder.Services.AddScoped<ITokens, Tokens>();

// Configurations
builder.Services.Configure<Mailtrap>(builder.Configuration.GetSection("Mailtrap"));

// Mailing
builder.Services.AddScoped<IEmail, RegisterEmail>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();