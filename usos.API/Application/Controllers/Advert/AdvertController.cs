using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices;
using usos.API.Application.Models;
using usos.API.Configurations;
using usos.API.Seeds;

namespace usos.API.Application.Controllers.Advert
{
    [ApiController]
    [Route("/api/adverts")]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet]
        [HasRoles(RoleSeed.RectorId, RoleSeed.DeaneryWorkerId, RoleSeed.LecturerId, RoleSeed.StudentId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(PaginationResponse<AdvertPaginationResponse>))]
        public async Task<IActionResult> GetAdverts([FromQuery] PaginationRequest request)
        {
            return Ok(await _advertService.GetAdverts(request));
        }

        [HttpPost]
        [HasRoles(RoleSeed.RectorId, RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateAdvert([FromBody] AdvertRequest request)
        {
            var advertId = await _advertService.CreateAdvert(request);
            return StatusCode(StatusCodes.Status201Created, advertId);
        }
        
        [HttpPut]
        [HasRoles(RoleSeed.RectorId, RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAdvert([FromQuery] Guid advertId, [FromBody] AdvertRequest request)
        {
            await _advertService.UpdateAdvert(advertId ,request);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        
        [HttpDelete]
        [HasRoles(RoleSeed.RectorId, RoleSeed.DeaneryWorkerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAdvert([FromQuery] Guid advertId)
        {
            await _advertService.DeleteAdvert(advertId);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}