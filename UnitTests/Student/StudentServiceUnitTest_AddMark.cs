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
        public async Task ShouldReturnMarkId_WhenAddMark()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            var response = await _studentService.AddMark(new StudentMarksRequest
            {
                StudentId = Guid.NewGuid(),
                SubjectId = Guid.NewGuid(),
                Mark = 4
            });
            
            Assert.IsType<Guid>(response);

            var studentSubject = _context.StudentSubject
                .AsNoTracking()
                .Single(x => x.StudentSubjectId == response);
            
            Assert.Equal(4,studentSubject.Mark);
        }
    }
}