using System;
using System.Threading.Tasks;
using usos.API.Application.Models;
using Xunit;

namespace UnitTests.Student
{
    public partial class StudentServiceUnitTest
    {
        
        public async Task ReturnGuid_WhenRequestStudentBody()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _studentService.CreateStudent(new StudentRequest
            {
                FirstName = "test1",
                Surname = "test1",
                Email = "test1@vp.pl",
                IndexNumber = 111111
            });

            Assert.IsType<Guid>(response);
        }
    }
}