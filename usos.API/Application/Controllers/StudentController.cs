using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.Models;
using usos.API.Entities;

namespace usos.API.Application.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentController : ControllerBase
    {
        private readonly UsosDbContext _usosDbContext;

        public StudentController(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }
        
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequest request)
        {
            var student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                IndexNumber = request.IndexNumber
            };

            await _usosDbContext.AddAsync(student);
            await _usosDbContext.SaveChangesAsync();
            
            return StatusCode(StatusCodes.Status201Created, student.StudentId);
        }
    }
}