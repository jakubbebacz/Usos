using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices;
using usos.API.Application.Models;
using usos.API.Configurations;
using usos.API.Seeds;

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
        [HasRoles(RoleSeed.RectorId, RoleSeed.StudentId, RoleSeed.LecturerId, RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(PaginationResponse<StudentPaginationResponse>))]
        public async Task<IActionResult> GetUsers([FromQuery] StudentPaginationRequest request)
        {
            return Ok(await _studentService.GetStudents(request));
        }
        
        [HttpGet("{studentId:guid}/subjects")]
        [HasRoles(RoleSeed.RectorId, RoleSeed.StudentId, RoleSeed.LecturerId, RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(IQueryable<IEnumerable<string>>))]
        public async Task<IActionResult> GetUsers([FromRoute] Guid studentId)
        {
            return Ok(await _studentService.GetStudentSubjects(studentId));
        }
        
        [HttpGet("{studentId:guid}/marks")]
        [HasRoles(RoleSeed.RectorId, RoleSeed.StudentId, RoleSeed.LecturerId, RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(IEnumerable<double[]>))]
        public async Task<IActionResult> GetStudentMarks([FromRoute] Guid studentId)
        {
            return Ok(await _studentService.GetStudentMarks(studentId));
        }
        
        [HttpGet("{studentId:guid}")]
        [HasRoles(RoleSeed.RectorId, RoleSeed.StudentId, RoleSeed.LecturerId, RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(StudentResponse))]
        public async Task<IActionResult> GetStudent([FromRoute] Guid studentId)
        {
            return Ok(await _studentService.GetStudent(studentId));
        }
        
        [HttpPost]
        [HasRoles(RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequest request)
        {
            var studentId = await _studentService.CreateStudent(request);
            return StatusCode(StatusCodes.Status201Created, studentId);
        }
        
        [HttpPost("mark")]
        [HasRoles(RoleSeed.LecturerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> AddMark([FromBody] StudentMarksRequest request)
        {
            var markId = await _studentService.AddMark(request);
            return StatusCode(StatusCodes.Status201Created, markId);
        }
        
        [HttpPut("{studentId:guid}")]
        [HasRoles(RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid studentId, [FromBody] StudentRequest request)
        {
            await _studentService.UpdateStudent(studentId ,request);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        
        [HttpDelete("{studentId:guid}")]
        [HasRoles(RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid studentId)
        {
            await _studentService.DeleteStudent(studentId);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}