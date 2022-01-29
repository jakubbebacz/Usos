using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Student
{
    public partial class StudentServiceUnitTest
    {
        [Fact]
        public async Task ShouldReturnStudent_When_GetId()
        {
            var studentId = Guid.NewGuid();
            
            var students = new[]
            {
                new usos.API.Entities.Student
                {
                    StudentId = studentId,
                    GroupId = Guid.NewGuid(),
                    FirstName = "test1",
                    Surname = "test1",
                    Email = "test1@vp.pl",
                    Password = "test1",
                    IndexNumber = 123456
                },
                new usos.API.Entities.Student
                {
                    StudentId = Guid.NewGuid(),
                    GroupId = Guid.NewGuid(),
                    FirstName = "test2",
                    Surname = "test2",
                    Email = "test2@vp.pl",
                    Password = "test2",
                    IndexNumber = 222222
                },
            };
            
            await _context.Database.EnsureDeletedAsync();
            await _context.Student.AddRangeAsync(students);
            await _context.SaveChangesAsync();
            
            var response = await  _studentService.GetStudent(studentId);
            
            Assert.Equal(response.StudentId, students[0].StudentId);
            Assert.Equal(response.GroupId, students[0].GroupId);
            Assert.Equal(response.FirstName, students[0].FirstName);
            Assert.Equal(response.Surname, students[0].Surname);
            Assert.Equal(response.Email, students[0].Email);
            Assert.Equal(response.IndexNumber, students[0].IndexNumber);
        }
    }
}