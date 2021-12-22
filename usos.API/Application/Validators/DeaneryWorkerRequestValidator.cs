using FluentValidation;
using usos.API.Application.Models;
using usos.API.Entities;

namespace usos.API.Application.Validators
{
    public class DeaneryWorkerRequestValidator : AbstractValidator<DeaneryWorkerRequest>
    {
        public DeaneryWorkerRequestValidator()
        {
            RuleFor(x => x.CardId)
                .MaximumLength(50)
                .NotEmpty();
            
            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .NotEmpty();
            
            RuleFor(x => x.Surname)
                .MaximumLength(50)
                .NotEmpty();
            
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(25)
                .NotEmpty();

            RuleFor(x => x.Email)
                .MaximumLength(100)
                .EmailAddress()
                .NotEmpty();
        }
    }
}