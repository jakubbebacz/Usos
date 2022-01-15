using FluentValidation;
using usos.API.Entities;

namespace usos.API.Application.Validators
{
    public class AdvertRequestValidator : AbstractValidator<Advert>
    {
        public AdvertRequestValidator()
        {
            RuleFor(x => x.DeaneryWorkerId)
                .NotEmpty();
            
            RuleFor(x => x.Title)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.Note)
                .MaximumLength(1000)
                .NotEmpty();
            
            RuleFor(x => x.Date)
                .NotEmpty();
        }
    }
}