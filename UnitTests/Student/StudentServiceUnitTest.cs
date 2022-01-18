using usos.API.Application.IServices;
using usos.API.Application.Services;

namespace UnitTests.Student
{
    public partial class StudentServiceUnitTest : DbContextConfigBase
    {
        private readonly IStudentService _studentService;

        public StudentServiceUnitTest()
        {
            _studentService = new StudentService(_context);
        }
    }
}