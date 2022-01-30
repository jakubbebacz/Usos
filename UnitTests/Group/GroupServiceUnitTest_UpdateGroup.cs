using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.Models.Group;
using Xunit;

namespace UnitTests.Group
{
    public partial class GroupServiceUnitTest
    {
        [Fact]
        public async Task ShouldUpdateGroup_WhenUpdateGroup()
        {
            var groupId = Guid.NewGuid();
            
            var group = new usos.API.Entities.Group
            {
                GroupId = groupId,
                Name = "test1",
                Term = 1
            };

            var request = new GroupUpdateRequest
            {
                Name = "test2",
                Term = 2
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
            await _context.AddRangeAsync(group);
            await _context.SaveChangesAsync();

            await _groupService.UpdateGroup(groupId, request);

            var fetchedGroup = _context.Group
                .AsNoTracking()
                .Single(x => x.GroupId == groupId);
            
            Assert.Equal(request.Name, fetchedGroup.Name);
            Assert.Equal(request.Term, fetchedGroup.Term);
        }
    }
}