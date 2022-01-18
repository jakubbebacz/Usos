using System;
using System.IO;
using System.Threading.Tasks;
using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using usos.API.Application.IServices.AuthHelpers;

namespace usos.API.Application.Services.AuthHelpers
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _fluentEmail;
        private readonly IConfiguration _configuration;
        private readonly ICryptService _cryptService;

        public EmailService(IFluentEmail fluentEmail, IConfiguration configuration, ICryptService cryptService)
        {
            _fluentEmail = fluentEmail;
            _configuration = configuration;
            _cryptService = cryptService;
        }
    
        public async Task SendEmailWithSetPasswordUrl(string receiver,
            string subject,
            Guid userId)
        {
            var token = _cryptService.EncryptToken(userId);
            var url = $"{_configuration["Urls:BaseUrl"]}set-password/?userId={userId}&token={token}";

            var email = _fluentEmail
                .To(receiver)
                .Subject(subject)
                .Body("https://localhost:5001/api/"+url);
            await email.SendAsync();
        }
    }
}