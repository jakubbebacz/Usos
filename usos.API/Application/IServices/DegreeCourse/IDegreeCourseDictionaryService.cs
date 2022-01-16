using System.Threading.Tasks;
using usos.API.Application.Models;
using usos.API.Application.Models.DegreeCourse;
using usos.API.Application.Models.Subject;

namespace usos.API.Application.IServices.DegreeCourse
{
    public interface IDegreeCourseDictionaryService
    {
        Task<PaginationResponse<DictionaryResponse>> GetDegreeCourses(DegreeCoursePaginationRequest request);
    }
}