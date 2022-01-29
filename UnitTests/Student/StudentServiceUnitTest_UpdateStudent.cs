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
        public async Task ShouldChangeStudent_WhenUpdateStudent()
        {
            var studentId = Guid.NewGuid();

            var student = new usos.API.Entities.Student
            {
                StudentId = studentId,
                GroupId = Guid.NewGuid(),
                FirstName = "test1",
                Surname = "test1",
                Email = "test1",
                IndexNumber = 123456
            };
            
            await _context.Database.EnsureDeletedAsync();
            await _context.Student.AddRangeAsync(student);
            await _context.SaveChangesAsync();

            var request = new StudentRequest
            {
                FirstName = "test2",
                Surname = "test2",
                Email = "test2",
                IndexNumber = 78901
            };

            await _studentService.UpdateStudent(studentId, request);

            var updatedStudent = _context.Student
                .AsNoTracking()
                .Single(x => x.StudentId == studentId);
            
            Assert.Equal(request.FirstName, updatedStudent.FirstName);
            Assert.Equal(request.Surname, updatedStudent.Surname);
            Assert.Equal(request.Email, updatedStudent.Email);
            Assert.Equal(request.IndexNumber, updatedStudent.IndexNumber);
        }
    }
}