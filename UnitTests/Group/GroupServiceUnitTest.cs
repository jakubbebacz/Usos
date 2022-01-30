using usos.API;
using usos.API.Application.IServices;
using usos.API.Application.Services;

namespace UnitTests.Group
{
    public partial class GroupServiceUnitTest: DbContextConfigBase
    {
        private IGroupService _groupService;
        
        public GroupServiceUnitTest()
        {
            _groupService = new GroupService(_context);
        }
    }
}