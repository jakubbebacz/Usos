using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices.Subject;
using usos.API.Application.Models;
using usos.API.Application.Models.Subject;
using usos.API.Extensions;

namespace usos.API.Application.Services.Subject
{
    public class SubjectService : ISubjectService
    {
        private readonly UsosDbContext _usosDbContext;

        public SubjectService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }

        public async Task<PaginationResponse<DictionaryResponse>> GetSubjects(SubjectPaginationRequest request)
        {
            var query = _usosDbContext.Subject.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Phrase))
            {
                query = query.Where(x =>
                    x.SubjectName.ToLower().Contains(request.Phrase.ToLower()));
            }
            
            if (request.DegreeCourseId != null)
            {
                query = query.Where(x => x.DegreeCourseId == request.DegreeCourseId);
            }
            
            query = query.OrderByRequest(request.SortBy, request.SortDir);

            return new PaginationResponse<DictionaryResponse>
            {
                List = await query.Skip(request.Skip)
                    .Take(request.Take)
                    .Select(x => new DictionaryResponse
                    {
                        Id = x.SubjectId,
                        Name = x.SubjectName
                    })
                    .ToListAsync(),
                TotalCount = await query.CountAsync()
            };
        }
    }
}