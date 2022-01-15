using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices.DegreeCourse;
using usos.API.Application.IServices.Department;

namespace usos.API.Application.Controllers.Dictionaries
{
    [Route("api/dictionaries")]
    [ApiController]
    public partial class DictionariesController : ControllerBase
    {
        private readonly IDegreeCourseDictionaryService _degreeCourseDictionaryService;
        private readonly IDepartmentService _departmentService;

        public DictionariesController(IDegreeCourseDictionaryService degreeCourseDictionaryService, 
            IDepartmentService departmentService)
        {
            _degreeCourseDictionaryService = degreeCourseDictionaryService;
            _departmentService = departmentService;
        }
    }
}