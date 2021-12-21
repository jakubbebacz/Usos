using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices;
using usos.API.Application.Models.Lecturer;
using usos.API.Libraries;

namespace usos.API.Application.Controllers
{
    [ApiController]
    [Route("api/lecturers")]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerService _lecturerService;

        public LecturerController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateGroup([FromBody] LecturerRequest request)
        {
            var lecturerId = await _lecturerService.CreateLecturer(request);
            return StatusCode(StatusCodes.Status201Created, lecturerId);
        }
        
        [HttpPut("{lecturerId:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateLecturer(Guid lecturerId, [FromBody] LecturerUpdateRequest request)
        {
            var res = await _lecturerService.UpdateLecturer(lecturerId, request);
            return res == ResultCode.NotFound ? NotFound() : StatusCode(StatusCodes.Status204NoContent);        }
        
        [HttpDelete("{lecturerId:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteLecturer(Guid lecturerId)
        {
            var res = await _lecturerService.DeleteLecturer(lecturerId);
            return res == ResultCode.NotFound ? NotFound() : StatusCode(StatusCodes.Status204NoContent);
        }
    }
}