using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Application.Models;
using Xunit;

namespace UnitTests.Student
{
    public partial class StudentServiceUnitTest
    {
        [Fact]
        public async Task ReturnGuid_WhenRequestStudentBody()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            var request = new StudentRequest
            {
                FirstName = "test1",
                Surname = "test1",
                Email = "test1@vp.pl",
                IndexNumber = 111111
            };

            var response = await _studentService.CreateStudent(request);

            Assert.IsType<Guid>(response);

            var student = _context.Student
                .AsNoTracking()
                .Single(x => x.StudentId == response);
            
            Assert.Equal(request.FirstName, student.FirstName);
        }
    }
}