using System.Threading.Tasks;
using usos.API.Application.Models;

namespace usos.API.Application.IServices.Department
{
    public interface IDepartmentService
    {
        Task<PaginationResponse<DictionaryResponse>> GetDepartments(PaginationRequest request);
    }
}