using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices.DegreeCourse;
using usos.API.Application.IServices.Department;
using usos.API.Application.IServices.Subject;

namespace usos.API.Application.Controllers.Dictionaries
{
    [Route("api/dictionaries")]
    [ApiController]
    public partial class DictionariesController : ControllerBase
    {
        private readonly IDegreeCourseDictionaryService _degreeCourseDictionaryService;
        private readonly IDepartmentService _departmentService;
        private readonly ISubjectService _subjectService;

        public DictionariesController(IDegreeCourseDictionaryService degreeCourseDictionaryService, 
            IDepartmentService departmentService,
            ISubjectService subjectService)
        {
            _degreeCourseDictionaryService = degreeCourseDictionaryService;
            _departmentService = departmentService;
            _subjectService = subjectService;
        }
    }
}