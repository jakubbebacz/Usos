using System.Threading.Tasks;
using usos.API.Application.Models;
using usos.API.Application.Models.Department;

namespace usos.API.Application.IServices.Department
{
    public interface IDepartmentService
    {
        Task<PaginationResponse<DictionaryResponse>> GetDepartments(DepartmentPaginationRequest request);
    }
}