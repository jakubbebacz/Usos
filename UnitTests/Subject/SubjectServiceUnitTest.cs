using usos.API.Application.IServices.Subject;
using usos.API.Application.Services.Subject;

namespace UnitTests.Subject
{
    public partial class SubjectServiceUnitTest: DbContextConfigBase
    {
        private ISubjectService _subjectService;
        
        public SubjectServiceUnitTest()
        {
            _subjectService = new SubjectService(_context);
        }
    }
}