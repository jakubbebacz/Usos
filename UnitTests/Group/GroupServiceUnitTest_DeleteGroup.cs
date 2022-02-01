using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Group
{
    public partial class GroupServiceUnitTest
    {
        [Fact]
        public async Task ShouldDeleteGroup_WhenDelete()
        {
            var groupId = Guid.NewGuid();

            var group = new usos.API.Entities.Group
            {
                GroupId = groupId
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
            await _context.AddRangeAsync(group);
            await _context.SaveChangesAsync();

            await _groupService.DeleteGroup(groupId);

            var groupFetched = _context.Group
                .AsNoTracking()
                .SingleOrDefault(x => x.GroupId == groupId);
            
            Assert.Null(groupFetched);
        }
    }
}