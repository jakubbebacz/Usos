using NSubstitute;
using usos.API.Application.IServices;
using usos.API.Application.IServices.AuthHelpers;
using usos.API.Application.Services;

namespace UnitTests.Lecturer
{
    public partial class LecturerServiceUnitTest: DbContextConfigBase
    {
        private ILecturerService _lecturerService;
        
        public LecturerServiceUnitTest()
        {
            var emailService = Substitute.For<IEmailService>();
            _lecturerService = new LecturerService(_context, emailService);
        }
    }
}