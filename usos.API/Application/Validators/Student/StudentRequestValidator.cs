using FluentValidation;
using usos.API.Application.Models;

namespace usos.API.Application.Validators
{
    public class StudentRequestValidator : AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .NotEmpty();
            
            RuleFor(x => x.Surname)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.Email)
                .MaximumLength(100)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.IndexNumber)
                .GreaterThan(0)
                .LessThanOrEqualTo(9999999)
                .NotEmpty();
        }
    }
}