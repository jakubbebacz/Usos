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
        public async Task ShouldReturnSubjects_WhenGivenStudentGuid()
        {
            var studentId = Guid.NewGuid();
            var groupId = Guid.NewGuid();
            var degreeCourseId = Guid.NewGuid();

            var students = new[]
            {
                new usos.API.Entities.Student
                {
                    StudentId = studentId,
                    GroupId = groupId,
                    Group = new Group
                    {
                        GroupId = groupId,
                        DegreeCourseId = degreeCourseId,
                        DegreeCourse = new DegreeCourse
                        {
                            DegreeCourseId = degreeCourseId,
                            Subjects = new List<usos.API.Entities.Subject>
                            {
                                new usos.API.Entities.Subject
                                {
                                    SubjectId = Guid.NewGuid(),
                                    SubjectName = "test1"
                                },
                                new usos.API.Entities.Subject
                                {
                                    SubjectId = Guid.NewGuid(),
                                    SubjectName = "test2"
                                }
                            }
                        }
                    }
                }
            };
            
            await _context.Database.EnsureDeletedAsync();
            await _context.Student.AddRangeAsync(students);
            await _context.SaveChangesAsync();
            
            var response = await _studentService.GetStudentSubjects(studentId);
            
            Assert.Equal(2, response.Count());
            
        }
    }
}