using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices.DegreeCourse;
using usos.API.Application.Models;
using usos.API.Extensions;

namespace usos.API.Application.Services.DegreeCourse
{
    public class DegreeCourseDictionaryService : IDegreeCourseDictionaryService
    {
        private readonly UsosDbContext _usosDbContext;

        public DegreeCourseDictionaryService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }
        
        public async Task<PaginationResponse<DictionaryResponse>> GetDegreeCourses(PaginationRequest request)
        {
            var query = _usosDbContext.DegreeCourse.AsNoTracking();

            query = query.OrderByRequest(request.SortBy, request.SortDir);
            
            return new PaginationResponse<DictionaryResponse>
            {
                List = await query.Skip(request.Skip)
                    .Take(request.Take)
                    .Select(x => new DictionaryResponse
                {
                    Id = x.DegreeCourseId,
                    Name = x.DegreeCourseName
                }).ToListAsync(),
                TotalCount = await query.CountAsync()
            };
        }
    }
}