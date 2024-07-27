using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Veterinarian_Dotnet_Api.App.Configuration;
using Veterinarian_Dotnet_Api.App.Emails.Interfaces;

namespace Veterinarian_Dotnet_Api.App.Emails;

public class RegisterEmail(IOptions<Mailtrap> mail) : IEmail
{
  private readonly Mailtrap _mail = mail.Value;

  public async Task Send(string to)
  {
    MimeMessage email = new();

    email.From.Add(MailboxAddress.Parse("veterinarian-dotnet@demomailtrap.com"));
    email.To.Add(MailboxAddress.Parse(to));
    email.Subject = "Bienvenido a nuestra plataforma veterinaria";

    string body = @"
    <h1>Bienvenido a nuestra plataforma</h1>
    <p>Estimado usuario,</p>
    <p>Estamos encantados de darte la bienvenida a nuestra plataforma veterinaria. Aquí encontrarás todos los servicios que necesitas para el cuidado de tus mascotas.</p>
    <p>Si tienes alguna pregunta, no dudes en contactarnos.</p>
    <p>¡Esperamos que disfrutes de tu experiencia con nosotros!</p>
    <p>Atentamente,<br>El equipo de la plataforma veterinaria</p>
    ";

    BodyBuilder builder = new() { HtmlBody = body };
    email.Body = builder.ToMessageBody();

    using SmtpClient smtp = new();
    await smtp.ConnectAsync(_mail.Host, _mail.Port, SecureSocketOptions.StartTls);
    await smtp.AuthenticateAsync(_mail.Username, _mail.Password);
    await smtp.SendAsync(email);
    await smtp.DisconnectAsync(true);
  }
}