using FluentValidation;
using usos.API.Application.Models.Questionnarie;

namespace usos.API.Application.Validators.Questionnarie
{
    public class QuestionnarieRequestValidator : AbstractValidator<QuestionnarieRequest>
    {
        public QuestionnarieRequestValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty();
            
            RuleFor(x => x.LecturerId)
                .NotEmpty();
            
            RuleFor(x => x.Note)
                .MaximumLength(1000)
                .NotEmpty();
            
            RuleFor(x => x.Rating)
                .LessThanOrEqualTo(10)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}