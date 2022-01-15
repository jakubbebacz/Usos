using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices.Questionnarie;
using usos.API.Application.Models;
using usos.API.Application.Models.Questionnarie;
using usos.API.Entities;

namespace usos.API.Application.Services.Questionnarie
{
    public class QuestionnarieService : IQuestionnarieService

    {
    private readonly UsosDbContext _usosDbContext;

    public QuestionnarieService(UsosDbContext usosDbContext)
    {
        _usosDbContext = usosDbContext;
    }

    public async Task<PaginationResponse<QuestionnariePaginationResponse>> GetQuestionnaries(
        QuestionnariePaginationRequest request)
    {
        var query = _usosDbContext.Questionnaire.AsNoTracking();

        return new PaginationResponse<QuestionnariePaginationResponse>
        {
            List = await query.Skip(request.Skip)
                .Take(request.Take)
                .Select(x => new QuestionnariePaginationResponse
                {
                    LecturerName = x.Lecturer.FirstName + " " + x.Lecturer.Surname,
                    Note = x.Note,
                    Rating = x.Rating
                }).ToListAsync(),
            TotalCount = await query.CountAsync()
        };
    }

    public async Task<Guid> CreateQuestionnarie(QuestionnarieRequest request)
    {
        var questionnarie = new Questionnaire
        {
            StudentId = request.StudentId,
            LecturerId = request.LecturerId,
            Note = request.Note,
            Rating = request.Rating
        };

        await _usosDbContext.AddAsync(questionnarie);
        await _usosDbContext.SaveChangesAsync();
        return questionnarie.QuestionnaireId;
    }
    }
}