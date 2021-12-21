using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices;
using usos.API.Application.Models;

namespace usos.API.Application.Controllers
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


        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateAdvert([FromBody] AdvertRequest request)
        {
            var advertId = await _advertService.CreateAdvert(request);
            return StatusCode(StatusCodes.Status201Created, advertId);
        }
    }
}