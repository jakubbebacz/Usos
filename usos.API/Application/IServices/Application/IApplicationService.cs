using System;
using System.Threading.Tasks;
using usos.API.Application.Models;
using usos.API.Application.Models.Application;

namespace usos.API.Application.IServices.Application
{
    public interface IApplicationService
    {
        Task<ApplicationResponse> GetSingleApplication(Guid applicationId);

        Task<PaginationResponse<ApplicationPaginationResponse>> GetApplications(ApplicationPaginationRequest request);
        
        Task<Guid> CreateApplication(Guid studentId, Guid recipentId, ApplicationRequest request);

        Task ApproveApplication(Guid applicationId);

        Task DeleteApplication(Guid applicationId);
    }
}