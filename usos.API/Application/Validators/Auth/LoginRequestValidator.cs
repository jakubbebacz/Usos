using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices.AuthHelpers;
using usos.API.Application.Models.Auth;

namespace usos.API.Application.Validators.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        private readonly UsosDbContext _usosDbContext;
        private readonly ICryptService _cryptService;

        public LoginRequestValidator(UsosDbContext usosDbContext, ICryptService cryptService)
        {
            _usosDbContext = usosDbContext;
            _cryptService = cryptService;
            
            RuleFor(l => l.Email)
                .MaximumLength(100)
                .EmailAddress()
                .NotEmpty();

            RuleFor(l => l.Password)
                .MaximumLength(250)
                .MinimumLength(6)
                .NotEmpty()
                .MustAsync(IsPasswordEqual)
                .WithMessage("Incorrect credentials");
        }
        
        private async Task<bool> IsPasswordEqual(LoginRequest request,
            string password,
            CancellationToken cancellationToken)
        {
            var userPassword = await _usosDbContext.Student
                .AsNoTracking()
                .Where(x => x.Email == request.Email)
                .Select(x => x.Password)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            return userPassword == _cryptService.EncryptPassword(password);
        }
    }
}