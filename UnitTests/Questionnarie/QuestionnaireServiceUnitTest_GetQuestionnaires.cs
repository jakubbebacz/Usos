using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Application.Models.Questionnarie;
using usos.API.Entities;
using Xunit;

namespace UnitTests.Questionnarie
{
    public partial class QuestionnaireServiceUnitTest
    {
        public async Task ReturnAllQuestionnaires_WhenGetQuestionnaires()
        {
            var questionnaires = new[]
            {
                new Questionnaire
                {
                    QuestionnaireId = Guid.NewGuid(),
                    StudentId = Guid.NewGuid(),
                    LecturerId = Guid.NewGuid(),
                    Note = "test1",
                    Rating = 4
                },
                new Questionnaire
                {
                    QuestionnaireId = Guid.NewGuid(),
                    StudentId = Guid.NewGuid(),
                    LecturerId = Guid.NewGuid(),
                    Note = "test2",
                    Rating = 5
                },
                new Questionnaire
                {
                    QuestionnaireId = Guid.NewGuid(),
                    StudentId = Guid.NewGuid(),
                    LecturerId = Guid.NewGuid(),
                    Note = "test3",
                    Rating = 6
                }
            };
            
            await _context.Database.EnsureCreatedAsync();
            await _context.Questionnaire.AddRangeAsync(questionnaires);
            await _context.SaveChangesAsync();
            await _context.Database.EnsureCreatedAsync();

            var response = await _questionnarieService.GetQuestionnaries(new QuestionnariePaginationRequest());
            
            Assert.Equal(questionnaires[0].LecturerId, response.List.ToList()[0].LecturerId);
        }
    }
}