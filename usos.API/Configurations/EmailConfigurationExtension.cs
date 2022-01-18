using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Silevis.Bike.Infrastructure.Configurations;

namespace usos.API.Configurations
{
  /// <summary>
  /// Extensions for Startup (Email)
  /// </summary>
  public static class EmailConfigurationExtension
  {
    /// <summary>
    /// Email configuration default implementation.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddEmail(this IServiceCollection services, IConfiguration configuration)
    {
      var email = configuration.GetSection("EMail").Get<EmailConfigurationModel>();

      services
        .AddFluentEmail(email.Sender, email.From)
        .AddRazorRenderer()
        .AddSmtpSender(new SmtpClient(email.Host)
        {
          UseDefaultCredentials = false,
          Port = email.Port,
          Credentials = new NetworkCredential(email.Sender, email.Password),
          EnableSsl = true
        });

      return services;
    }
  }
}