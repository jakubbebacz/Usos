using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Entities;
using Xunit;

namespace UnitTests.Student
{
    public partial class StudentServiceUnitTest
    {
        [Fact]
        public async Task ShouldReturnSubjects_When_GivenGuid()
        {
            var studentId = Guid.NewGuid();
            var subjectId = Guid.NewGuid();

            var student = new []
            {
                new usos.API.Entities.Student
                {
                    StudentId = studentId,
                    GroupId = Guid.NewGuid(),
                    FirstName = "test1",
                    Surname = "test1",
                    Email = "test1@vp.pl",
                    Password = "test1",
                    IndexNumber = 123456,
                    StudentSubjects = new List<StudentSubject>
                    {
                        new StudentSubject
                        {
                            StudentSubjectId = Guid.NewGuid(),
                            StudentId = studentId,
                            SubjectId = subjectId,
                            Mark = 4
                        },
                        new StudentSubject
                        {
                            StudentSubjectId = Guid.NewGuid(),
                            StudentId = studentId,
                            SubjectId = subjectId,
                            Mark = 3
                        }
                    }
                }
                
            };
            
            await _context.Database.EnsureDeletedAsync();
            await _context.Student.AddRangeAsync(student);
            await _context.SaveChangesAsync();
            
            var response = await _studentService.GetStudentMarks(studentId);
            
            Assert.Equal(2, response.Count());
        }
    }
}