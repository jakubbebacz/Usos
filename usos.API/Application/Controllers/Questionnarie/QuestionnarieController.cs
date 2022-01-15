using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices.Questionnarie;
using usos.API.Application.Models;
using usos.API.Application.Models.Questionnarie;

namespace usos.API.Application.Controllers.Questionnarie
{
    [ApiController]
    [Route("/api/questionnaries")]
    public class QuestionnarieController : ControllerBase
    {
        private readonly IQuestionnarieService _questionnarieService;

        public QuestionnarieController(IQuestionnarieService questionnarieService)
        {
            _questionnarieService = questionnarieService;
        }
        
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(PaginationResponse<QuestionnariePaginationResponse>))]
        public async Task<IActionResult> GetQuestionnaries([FromQuery] QuestionnariePaginationRequest request)
        {
            return Ok(await _questionnarieService.GetQuestionnaries(request));
        }
        
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType(typeof(Guid))]
        public async Task<IActionResult> CreateStudent([FromBody] QuestionnarieRequest request)
        {
            var questionnarieId = await _questionnarieService.CreateQuestionnarie(request);
            return StatusCode(StatusCodes.Status201Created, questionnarieId);
        }
    }
}