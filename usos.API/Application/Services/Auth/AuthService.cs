using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices.Auth;
using usos.API.Application.IServices.AuthHelpers;
using usos.API.Application.Models.Auth;
using usos.API.Configurations;
using usos.API.Globals;

namespace usos.API.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UsosDbContext _usosDbContext;
        private readonly ICryptService _cryptService;
        private readonly IHttpContextExtendAccessor _httpContextExtendAccessor;

        public AuthService(UsosDbContext usosDbContext,
            ICryptService cryptService,
            IHttpContextExtendAccessor httpContextExtendAccessor)
        {
            _usosDbContext = usosDbContext;
            _cryptService = cryptService;
            _httpContextExtendAccessor = httpContextExtendAccessor;
        }

        public async Task<(string userId, string email, string roleId)> Login(LoginRequest request)
        {
            var student = await _usosDbContext.Student.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (student != null)
            {
                return (student.StudentId.ToString(), student.Email, student.RoleId.ToString());
            }
            
            var lecturer = await _usosDbContext.Lecturer.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (lecturer != null)
            {
                return (lecturer.LecturerId.ToString(), lecturer.Email, lecturer.RoleId.ToString());
            }
            
            var deaneryWorker = await _usosDbContext.DeaneryWorker.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (deaneryWorker != null)
            {
                return (deaneryWorker.DeaneryWorkerId.ToString(), deaneryWorker.Email, deaneryWorker.RoleId.ToString());
            }
            
            var rector = await _usosDbContext.Rector.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (rector != null)
            {
                return (rector.RectorId.ToString(), rector.Email, rector.RoleId.ToString());
            }

            throw new BusinessNotFoundException("Wrong email/password");
        }

        public async Task SetPassword(Guid userId,
            string token,
            SetPasswordRequest request)
        {
            var confirmationToken = "";
            dynamic type = new System.Dynamic.ExpandoObject();
            
            var student = await _usosDbContext.Student.SingleOrDefaultAsync(x => x.StudentId == userId);
            if (student != null)
            {
                confirmationToken = _cryptService.EncryptToken(student.StudentId);
                type.User = student;
            }
            
            var lecturer = await _usosDbContext.Lecturer.SingleOrDefaultAsync(x => x.LecturerId == userId);
            if (lecturer != null)
            {
                confirmationToken = _cryptService.EncryptToken(lecturer.LecturerId);
                type.User = lecturer;
            }
            
            var deaneryWorker = await _usosDbContext.DeaneryWorker.SingleOrDefaultAsync(x => x.DeaneryWorkerId == userId);
            if (deaneryWorker != null)
            {
                confirmationToken = _cryptService.EncryptToken(deaneryWorker.DeaneryWorkerId);
                type.User = deaneryWorker;
            }
            
            
            var rector = await _usosDbContext.Rector.SingleOrDefaultAsync(x => x.RectorId == userId);
            if (rector != null)
            {
                confirmationToken = _cryptService.EncryptToken(rector.RectorId);
                type.User = rector;
            }
            
            if (confirmationToken != token)
            {
                throw new BusinessException("Confirmation link does not work anymore");
            }

            type.User.Password = _cryptService.EncryptPassword(request.NewPassword);
            type.User.IsPasswordChangeRequired = false;
            
            await _usosDbContext.SaveChangesAsync();
        }

        public async Task<CurrentUserResponse> GetCurrentUser()
        {
            var response = new CurrentUserResponse();
            
            var student = await _usosDbContext.Student.SingleOrDefaultAsync(x => x.StudentId == _httpContextExtendAccessor.UserId);
            if (student != null)
            {
                response.UserId = student.StudentId;
                response.RoleId = student.RoleId;
            }
            
            var lecturer = await _usosDbContext.Lecturer.SingleOrDefaultAsync(x => x.LecturerId == _httpContextExtendAccessor.UserId);
            if (lecturer != null)
            {
                response.UserId = lecturer.LecturerId;
                response.RoleId = lecturer.RoleId;
            }
            
            var deaneryWorker = await _usosDbContext.DeaneryWorker.SingleOrDefaultAsync(x => x.DeaneryWorkerId == _httpContextExtendAccessor.UserId);
            if (deaneryWorker != null)
            {
                response.UserId = deaneryWorker.DeaneryWorkerId;
                response.RoleId = deaneryWorker.RoleId;
            }
            
            var rector = await _usosDbContext.Rector.SingleOrDefaultAsync(x => x.RectorId == _httpContextExtendAccessor.UserId);
            if (rector != null)
            {
                response.UserId = rector.RectorId;
                response.RoleId = rector.RoleId;
            }

            return response;
        }
    }
}