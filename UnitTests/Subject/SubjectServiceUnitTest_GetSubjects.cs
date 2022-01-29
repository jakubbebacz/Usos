using System;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Application.Models.Subject;
using Xunit;

namespace UnitTests.Subject
{
    public partial class SubjectServiceUnitTest
    {
        [Fact]
        public async Task ShouldReturnSubjects_WhenGet()
        {
            var subjects = new[]
            {
                new usos.API.Entities.Subject
                {
                    SubjectId = Guid.NewGuid(),
                    DegreeCourseId = Guid.NewGuid(),
                    SubjectName = "test1"
                },
                new usos.API.Entities.Subject
                {
                    SubjectId = Guid.NewGuid(),
                    DegreeCourseId = Guid.NewGuid(),
                    SubjectName = "test2"
                }
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.Subject.AddRangeAsync(subjects);
            await _context.SaveChangesAsync();
            await _context.Database.EnsureCreatedAsync();

            var response = await _subjectService.GetSubjects(new SubjectPaginationRequest());
            
            Assert.True(response.TotalCount == 2);
            Assert.Equal(subjects[0].SubjectId, response.List.ToList()[0].Id);
            Assert.Equal(subjects[0].SubjectName, response.List.ToList()[0].Name);

            Assert.Equal(subjects[1].SubjectId, response.List.ToList()[1].Id);
            Assert.Equal(subjects[1].SubjectName, response.List.ToList()[1].Name);
        }
    }
}