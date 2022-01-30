using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices.Application;
using usos.API.Application.Models;
using usos.API.Application.Models.Application;
using usos.API.Application.Models.Lecturer;
using usos.API.Configurations;
using usos.API.Seeds;

namespace usos.API.Application.Controllers.Application
{
    [ApiController]
    [Route("/api/applications")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("{applicationId::guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(ApplicationResponse))]
        public async Task<IActionResult> GetApplication(Guid applicationId)
        {
            var response = await _applicationService.GetSingleApplication(applicationId);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(PaginationResponse<ApplicationPaginationResponse>))]
        public async Task<IActionResult> GetApplications([FromQuery] ApplicationPaginationRequest request)
        {
            var response = await _applicationService.GetApplications(request);
            return Ok(response);
        }

        
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateApplication([FromQuery] Guid studentId, [FromQuery] Guid recipientId,
            [FromBody] ApplicationRequest request)
        {
            var applicationId = await _applicationService.CreateApplication(studentId, recipientId, request);
            return StatusCode(StatusCodes.Status201Created, applicationId);
        }
        
        [HttpPut("approve/")]
        [HasRoles(RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ApproveApplication([FromQuery] Guid applicationId)
        {
            await _applicationService.ApproveApplication(applicationId);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        
        [HttpDelete]
        [HasRoles(RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteApplication([FromQuery] Guid applicationId)
        {
            await _applicationService.DeleteApplication(applicationId);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}