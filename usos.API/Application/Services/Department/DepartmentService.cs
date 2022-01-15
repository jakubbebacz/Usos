using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usos.API.Application.IServices.Department;
using usos.API.Application.Models;
using usos.API.Extensions;

namespace usos.API.Application.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly UsosDbContext _usosDbContext;

        public DepartmentService(UsosDbContext usosDbContext)
        {
            _usosDbContext = usosDbContext;
        }

        public async Task<PaginationResponse<DictionaryResponse>> GetDepartments(PaginationRequest request)
        {
            var query = _usosDbContext.Department.AsNoTracking();

            query = query.OrderByRequest(request.SortBy, request.SortDir);

            return new PaginationResponse<DictionaryResponse>
            {
                List = await query.Skip(request.Skip)
                    .Take(request.Take)
                    .Select(x => new DictionaryResponse
                    {
                        Id = x.DepartmentId,
                        Name = x.DepartmentName
                    }).ToListAsync(),
                TotalCount = await query.CountAsync()
            };
        }
    }
}