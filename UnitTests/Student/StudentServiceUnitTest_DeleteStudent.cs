using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Student
{
    public partial class StudentServiceUnitTest
    {
        [Fact]
        public async Task ShouldDeleteStudent_WhenDeleteStudent()
        {
            var studentId = Guid.NewGuid();

            var student = new usos.API.Entities.Student
            {
                StudentId = studentId,
                FirstName = "test1",
                Surname = "test1"
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.Student.AddRangeAsync(student);
            await _context.SaveChangesAsync();
            await _context.Database.EnsureCreatedAsync();

            await _studentService.DeleteStudent(studentId);

            var studentFetched = _context.Student
                .AsNoTracking()
                .SingleOrDefault(x => x.StudentId == studentId);
            
            Assert.Null(studentFetched);
        }
    }
}