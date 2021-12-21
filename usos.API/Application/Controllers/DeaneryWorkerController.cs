using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices;
using usos.API.Application.Models;

namespace usos.API.Application.Controllers
{
    [ApiController]
    [Route("/api/deaneryWorkers")]
    public class DeaneryWorkerController : ControllerBase
    {
        private readonly IDeaneryWorkerService _deaneryWorkerService;

        public DeaneryWorkerController(IDeaneryWorkerService deaneryWorkerService)
        {
            _deaneryWorkerService = deaneryWorkerService;
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
    }
}