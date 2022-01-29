using usos.API.Application.IServices.Questionnarie;
using usos.API.Application.Services.Questionnarie;

namespace UnitTests.Questionnarie
{
    public partial class QuestionnaireServiceUnitTest : DbContextConfigBase
    {
        private readonly IQuestionnarieService _questionnarieService;
        
        public QuestionnaireServiceUnitTest()
        {
            _questionnarieService = new QuestionnarieService(_context);
        }
    }
}