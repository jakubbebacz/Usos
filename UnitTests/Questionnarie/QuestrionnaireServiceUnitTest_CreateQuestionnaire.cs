using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using usos.API.Application.Models.Questionnarie;
using Xunit;

namespace UnitTests.Questionnarie
{
    public partial class QuestionnaireServiceUnitTest
    {
        [Fact]
        public async Task ShouldReturnGuid_WhenCreate()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            var request = new QuestionnarieRequest
            {
                StudentId = Guid.NewGuid(),
                LecturerId = Guid.NewGuid(),
                Note = "test1",
                Rating = 3
            };

            var response = await _questionnarieService.CreateQuestionnarie(request);
            
            Assert.IsType<Guid>(response);

            var questionaireFetched = _context.Questionnaire
                .AsNoTracking()
                .Single(x => x.QuestionnaireId == response);
            
            Assert.Equal(request.StudentId, questionaireFetched.StudentId);
            Assert.Equal(request.LecturerId, questionaireFetched.LecturerId);
            Assert.Equal(request.Note, questionaireFetched.Note);
            Assert.Equal(request.Rating, questionaireFetched.Rating);
        }
    }
}