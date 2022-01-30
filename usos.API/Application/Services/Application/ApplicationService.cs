using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices.Application;
using usos.API.Application.Models;
using usos.API.Application.Models.Application;
using usos.API.Configurations;
using usos.API.Globals;
using usos.API.Seeds;

namespace usos.API.Application.Services.Application
{
    public class ApplicationService : IApplicationService
    {
        private readonly UsosDbContext _usosDbContext;
        private readonly IHttpContextExtendAccessor _httpContextExtendAccessor;

        public ApplicationService(UsosDbContext usosDbContext, IHttpContextExtendAccessor httpContextExtendAccessor)
        {
            _usosDbContext = usosDbContext;
            _httpContextExtendAccessor = httpContextExtendAccessor;
        }

        public async Task<ApplicationResponse> GetSingleApplication(Guid applicationId)
        {
            await _usosDbContext.Application
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.ApplicationId == applicationId);

            var application = await _usosDbContext.Application
                .AsNoTracking()
                .SingleAsync(x => x.ApplicationId == applicationId);

            return new ApplicationResponse
            {
                studentId = application.StudentId,
                reciepentId = application.Recipent,
                note = application.Note,
                title = application.Title,
                isAccepted = application.IsAccepted
            };
        }

        public async Task<PaginationResponse<ApplicationPaginationResponse>> GetApplications(ApplicationPaginationRequest request)
        {
            var query = _usosDbContext.Application.AsNoTracking();

            if (_httpContextExtendAccessor.RoleId == RoleSeed.Student)
            {
                query = query.Where(x => x.StudentId == _httpContextExtendAccessor.UserId);
            }

            if (request.StudentId.HasValue)
            {
                query = query.Where(x => x.StudentId == request.StudentId);
            }

            return new PaginationResponse<ApplicationPaginationResponse>
            {
                List = await query.Skip(request.Skip)
                    .Take(request.Take)
                    .Select(x => new ApplicationPaginationResponse
                    {
                        Note = x.Note,
                        Title = x.Title,
                        ApplicationId = x.ApplicationId,
                        IsApproved = x.IsAccepted,
                        RecipientId = x.Recipent,
                        StudentId = x.StudentId
                    }).ToListAsync(),
                TotalCount = await query.CountAsync()
            };
        }

        public async Task<Guid> CreateApplication(Guid studentId, Guid recipentId, ApplicationRequest request)
        {
            var application = new Entities.Application
            {
                StudentId = studentId,
                Recipent = recipentId,
                Title = request.Title,
                Note = request.Note,
                IsAccepted = false
            };

            await _usosDbContext.AddAsync(application);
            await _usosDbContext.SaveChangesAsync();

            return application.ApplicationId;
        }

        public async Task ApproveApplication(Guid applicationId)
        {
            await _usosDbContext.Application
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.ApplicationId == applicationId);

            var application = await _usosDbContext.Application.SingleAsync(x => x.ApplicationId == applicationId);

            application.IsAccepted = true;

            await _usosDbContext.SaveChangesAsync();
        }

        public async Task DeleteApplication(Guid applicationId)
        {
            await _usosDbContext.Application
                .AsNoTracking()
                .IsAnyRuleAsync(x => x.ApplicationId == applicationId);

            var application = await _usosDbContext.Application.SingleAsync(x => x.ApplicationId == applicationId);
            _usosDbContext.Application.Remove(application);
            await _usosDbContext.SaveChangesAsync();
        }
    }
}