using System.Linq;
using usos.API.Entities;

namespace usos.API.Extensions
{
    public static partial class OrderByRequestExtension
    {
        public static IQueryable<Department> OrderByRequest(this IQueryable<Department> query, string sortBy, string sortDir)
        {
            return true switch
            {
                _ when IsSortBy(sortBy, nameof(Department.DepartmentName)) =>
                    IsSortDir(sortDir)
                        ? query.OrderBy(x => x.DepartmentName)
                        : query.OrderByDescending(x => x.DepartmentName),

                _ => query.OrderBy(x => x.DepartmentName)
            };
        }
    }
}