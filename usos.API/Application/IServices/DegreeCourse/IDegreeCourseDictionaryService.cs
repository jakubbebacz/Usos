using System.Threading.Tasks;
using usos.API.Application.Models;

namespace usos.API.Application.IServices.DegreeCourse
{
    public interface IDegreeCourseDictionaryService
    {
        Task<PaginationResponse<DictionaryResponse>> GetDegreeCourses(PaginationRequest request);
    }
}