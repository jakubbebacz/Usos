using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices;
using usos.API.Application.Models.Group;
using usos.API.Libraries;

namespace usos.API.Application.Controllers.Group
{

    [ApiController]
    [Route("api/groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateGroup([FromBody] GroupRequest request)
        {
            var groupId = await _groupService.CreateGroup(request);
            return StatusCode(StatusCodes.Status201Created, groupId);
        }
        
        [HttpPut("/students")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> AddStudentsToGroup([FromBody] AddStudentsToGroupRequest request)
        {
            var studentsId = await _groupService.AddStudentsToGroup(request);
            return StatusCode(StatusCodes.Status201Created, studentsId);
        }

        [HttpPut("{groupId:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateGroup(Guid groupId, [FromBody] GroupUpdateRequest request)
        {
            var res = await _groupService.UpdateGroup(groupId, request);
            return res == ResultCode.NotFound ? NotFound() : StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{groupId:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteGroup(Guid groupId)
        {
            var res = await _groupService.DeleteGroup(groupId);
            return res == ResultCode.NotFound ? NotFound() : StatusCode(StatusCodes.Status204NoContent);
        }
    }
}