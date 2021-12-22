using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices;
using usos.API.Application.Models;

namespace usos.API.Application.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequest request)
        {
            var studentId = await _studentService.CreateStudent(request);
            return StatusCode(StatusCodes.Status201Created, studentId);
        }
        
        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateStudent([FromQuery] Guid studentId, [FromBody] StudentRequest request)
        {
            await _studentService.UpdateStudent(studentId ,request);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        
        [HttpDelete]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteStudent([FromQuery] Guid studentId)
        {
            await _studentService.DeleteStudent(studentId);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}