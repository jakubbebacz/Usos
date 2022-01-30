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
        public async Task ShouldReturnGuid_WhenCreateGroup()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            var request = new GroupRequest
            {
                Name = "test1",
                Term = 1,
                DegreeCourseId = Guid.NewGuid()
            };

            var response = await _groupService.CreateGroup(request);

            Assert.IsType<Guid>(response);

            var group = _context.Group
                .AsNoTracking()
                .Single(x => x.GroupId == response);
            
            Assert.Equal(request.Name, group.Name);
            Assert.Equal(request.Term, group.Term);
            Assert.Equal(request.DegreeCourseId, group.DegreeCourseId);
        }
    }
}