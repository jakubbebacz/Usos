using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices;
using usos.API.Application.Models;
using usos.API.Configurations;
using usos.API.Seeds;

namespace usos.API.Application.Controllers.DeaneryWorker
{
    [ApiController]
    [HasRoles(RoleSeed.RectorId)]
    [Route("/api/deaneryWorkers")]
    public class DeaneryWorkerController : ControllerBase
    {
        private readonly IDeaneryWorkerService _deaneryWorkerService;

        public DeaneryWorkerController(IDeaneryWorkerService deaneryWorkerService)
        {
            _deaneryWorkerService = deaneryWorkerService;
        }

        [HttpGet]
        [HasRoles(RoleSeed.RectorId, RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType(typeof(PaginationResponse<DeaneryWorkerPaginationResponse>))]
        public async Task<IActionResult> GetDeaneryWorkers([FromQuery] DeaneryWorkerPaginationRequest request)
        {
            return Ok(await _deaneryWorkerService.GetDeaneryWorkers(request));
        }
        
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateDeaneryWorker([FromBody] DeaneryWorkerRequest request)
        {
            var deaneryWorkerId = await _deaneryWorkerService.CreateDeaneryWorker(request);
            return StatusCode(StatusCodes.Status201Created, deaneryWorkerId);
        }
        
        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateDeaneryWorker([FromQuery] Guid deaneryWorkerId, [FromBody] DeaneryWorkerRequest request)
        {
            await _deaneryWorkerService.UpdateDeaneryWorker(deaneryWorkerId ,request);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        
        [HttpDelete]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteDeaneryWorker([FromQuery] Guid deaneryWorkerId)
        {
            await _deaneryWorkerService.DeleteDeaneryWorker(deaneryWorkerId);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}