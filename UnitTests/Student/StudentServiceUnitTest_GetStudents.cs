using System;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Application.Models;
using Xunit;

namespace UnitTests.Student
{
    public partial class StudentServiceUnitTest
    {
        [Fact]
        public async Task ShouldReturnStudents_When_GetStudents()
        {
            var students = new[]
            {
                new usos.API.Entities.Student
                {
                    StudentId = Guid.NewGuid(),
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
            
            var response = await  _studentService.GetStudents(new StudentPaginationRequest
            {
                SortBy = "FirstName"
            });
            
            Assert.Equal(response.List.ToList()[0].StudentId, students[0].StudentId);
            Assert.Equal(response.List.ToList()[0].GroupId, students[0].GroupId);
            Assert.Equal(response.List.ToList()[0].FirstName, students[0].FirstName);
            Assert.Equal(response.List.ToList()[0].Surname, students[0].Surname);
            Assert.Equal(response.List.ToList()[0].Email, students[0].Email);
            Assert.Equal(response.List.ToList()[0].IndexNumber, students[0].IndexNumber);
            
            Assert.Equal(response.List.ToList()[1].StudentId, students[1].StudentId);
            Assert.Equal(response.List.ToList()[1].GroupId, students[1].GroupId);
            Assert.Equal(response.List.ToList()[1].FirstName, students[1].FirstName);
            Assert.Equal(response.List.ToList()[1].Surname, students[1].Surname);
            Assert.Equal(response.List.ToList()[1].Email, students[1].Email);
            Assert.Equal(response.List.ToList()[1].IndexNumber, students[1].IndexNumber);

        }
    }
}