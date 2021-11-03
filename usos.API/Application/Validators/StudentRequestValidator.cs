using FluentValidation;
using usos.API.Application.Models;

namespace usos.API.Application.Validators
{
    public class StudentRequestValidator : AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
        {
            RuleFor(s => s.FirstName)
                .MaximumLength(50)
                .NotEmpty();
            
            RuleFor(s => s.LastName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(s => s.Email)
                .MaximumLength(100)
                .EmailAddress()
                .NotEmpty();

            RuleFor(s => s.IndexNumber)
                .GreaterThan(0)
                .LessThanOrEqualTo(999999999)
                .NotEmpty();
        }
    }
}