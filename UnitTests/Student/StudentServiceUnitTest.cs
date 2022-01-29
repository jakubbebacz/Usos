using NSubstitute;
using usos.API.Application.IServices;
using usos.API.Application.IServices.AuthHelpers;
using usos.API.Application.Services;

namespace UnitTests.Student
{
    public partial class StudentServiceUnitTest : DbContextConfigBase
    {
        private readonly IStudentService _studentService;
        
        public StudentServiceUnitTest()
        {
            var emailService = Substitute.For<IEmailService>();
            _studentService = new StudentService(_context, emailService);
        }
    }
}