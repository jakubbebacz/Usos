using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Application.Models.Group;
using Xunit;

namespace UnitTests.Group
{
    public partial class GroupServiceUnitTest
    {
        [Fact]
        public async Task ShouldAddStudent_WhenAddStudent()
        {
            var groupId = Guid.NewGuid();
            var studentId1 = Guid.NewGuid();
            var studentId2 = Guid.NewGuid();
            
            var request = new AddStudentsToGroupRequest
            {
                GroupId = groupId,
                StudentsId = new Guid[] {studentId1, studentId2}
            };

            object[] students = {
                new usos.API.Entities.Student
                {
                    StudentId = studentId1
                },
                new usos.API.Entities.Student
                {
                    StudentId = studentId2
                }
            };

            var group = new usos.API.Entities.Group
            {
                GroupId = groupId,
                Name = "test1"
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
            await _context.AddRangeAsync(group);
            await _context.AddRangeAsync(students);
            await _context.SaveChangesAsync();

            await _groupService.AddStudentsToGroup(request);

            var groupFetched = _context.Group
                .AsNoTracking()
                .Single(x => x.GroupId == groupId);
            
            Assert.Equal(2, groupFetched.Students.Count());
        }
    }
}