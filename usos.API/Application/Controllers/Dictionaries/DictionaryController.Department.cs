using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.Models;

namespace usos.API.Application.Controllers.Dictionaries
{
    public partial class DictionariesController
    {
        [HttpGet("departments")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(PaginationResponse<DictionaryResponse>))]
        public async Task<IActionResult> GetDepartments([FromQuery] PaginationRequest request)
        {
            return Ok(await _departmentService.GetDepartments(request));
        }
    }
}