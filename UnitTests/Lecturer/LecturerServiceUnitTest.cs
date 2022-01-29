using usos.API.Application.IServices;
using usos.API.Application.Services;

namespace UnitTests.Lecturer
{
    public partial class LecturerServiceUnitTest: DbContextConfigBase
    {
        private ILecturerService _lecturerService;
        
        public LecturerServiceUnitTest()
        {
            _lecturerService = new LecturerService(_context);
        }
    }
}