using System;
using System.Threading.Tasks;
using usos.API.Application.Models;
using usos.API.Application.Models.Questionnarie;

namespace usos.API.Application.IServices.Questionnarie
{
    public interface IQuestionnarieService
    {
        Task<PaginationResponse<QuestionnariePaginationResponse>> GetQuestionnaries(QuestionnariePaginationRequest request);

        Task<Guid> CreateQuestionnarie(QuestionnarieRequest request);
    }
}