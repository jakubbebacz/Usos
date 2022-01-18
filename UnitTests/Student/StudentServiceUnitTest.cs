using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using usos.API.Application.IServices;
using usos.API.Application.IServices.AuthHelpers;
using usos.API.Application.Services;
using usos.API.Application.Services.AuthHelpers;

namespace UnitTests.Student
{
    public partial class StudentServiceUnitTest : DbContextConfigBase
    {
        private readonly IStudentService _studentService;
        private readonly IEmailService _emailService;
        private readonly IFluentEmail _fluentEmail;
        private readonly IConfiguration _configuration;
        private readonly ICryptService _cryptService;
        

        public StudentServiceUnitTest()
        {
            _emailService = new EmailService(_fluentEmail, _configuration, _cryptService);
            _studentService = new StudentService(_context, _emailService);
        }
    }
}