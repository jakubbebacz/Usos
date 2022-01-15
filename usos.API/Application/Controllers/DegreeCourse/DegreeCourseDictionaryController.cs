using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices.DegreeCourse;
using usos.API.Application.Models;

namespace usos.API.Application.Controllers.DegreeCourse
{
    [ApiController]
    [Route("/api/degree-courses")]
    public class DegreeCourseDictionaryController : ControllerBase
    {
        private readonly IDegreeCourseDictionaryService _degreeCourseDictionaryService;

        public DegreeCourseDictionaryController(IDegreeCourseDictionaryService degreeCourseDictionaryService)
        {
            _degreeCourseDictionaryService = degreeCourseDictionaryService;
        }
        
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(PaginationResponse<DictionaryResponse>))]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationRequest request)
        {
            return Ok(await _degreeCourseDictionaryService.GetDegreeCourses(request));
        }
    }
}