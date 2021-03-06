using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.Models;
using usos.API.Application.Models.Subject;

namespace usos.API.Application.Controllers.Dictionaries
{
    public partial class DictionariesController
    {
        [HttpGet("subjects")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(PaginationResponse<DictionaryResponse>))]
        public async Task<IActionResult> GetDegreeCourses([FromQuery] SubjectPaginationRequest request)
        {
            return Ok(await _subjectService.GetSubjects(request));
        }
    }
}