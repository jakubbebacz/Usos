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
                .NotEmpty()
                .MustAsync(IsPasswordEqual)
                .WithMessage("Incorrect credentials");
        }
        
        private async Task<bool> IsPasswordEqual(LoginRequest request,
            string password,
            CancellationToken cancellationToken)
        {
            var userPassword = "";
            
            var student = await _usosDbContext.Student.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (student != null)
            {
                userPassword = student.Password;
            }
            
            var lecturer = await _usosDbContext.Lecturer.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (lecturer != null)
            {
                userPassword = lecturer.Password;
            }
            
            var deaneryWorker = await _usosDbContext.DeaneryWorker.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (deaneryWorker != null)
            {
                userPassword = deaneryWorker.Password;
            }
            
            var rector = await _usosDbContext.Rector.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (rector != null)
            {
                userPassword = rector.Password;
            }

            return userPassword == _cryptService.EncryptPassword(password);
        }
    }
}