using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices.DegreeCourse;

namespace usos.API.Application.Controllers.Dictionaries
{
    [Route("api/dictionaries")]
    [ApiController]
    public partial class DictionariesController : ControllerBase
    {
        private readonly IDegreeCourseDictionaryService _degreeCourseDictionaryService;

        public DictionariesController(IDegreeCourseDictionaryService degreeCourseDictionaryService)
        {
            _degreeCourseDictionaryService = degreeCourseDictionaryService;
        }
    }
}