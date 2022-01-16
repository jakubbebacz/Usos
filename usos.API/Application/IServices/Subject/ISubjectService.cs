using System.Threading.Tasks;
using usos.API.Application.Models;
using usos.API.Application.Models.Subject;

namespace usos.API.Application.IServices.Subject
{
    public interface ISubjectService
    {
        Task<PaginationResponse<DictionaryResponse>> GetSubjects(SubjectPaginationRequest request);
    }
}