using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices;
using usos.API.Application.Models;

namespace usos.API.Application.Controllers.Student
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
        
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(PaginationResponse<StudentPaginationResponse>))]
        public async Task<IActionResult> GetUsers([FromQuery] StudentPaginationRequest request)
        {
            return Ok(await _studentService.GetStudents(request));
        }
        
        [HttpGet("/{studentId:guid}/subjects")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(StudentSubjectsResponse))]
        public async Task<IActionResult> GetUsers([FromRoute] Guid studentId)
        {
            return Ok(await _studentService.GetStudentSubjects(studentId));
        }
        
        [HttpGet("/{studentId:guid}/marks")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(IEnumerable<double[]>))]
        public async Task<IActionResult> GetStudentMarks([FromRoute] Guid studentId)
        {
            return Ok(await _studentService.GetStudentMarks(studentId));
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