using System.Linq;
using usos.API.Entities;

namespace usos.API.Extensions
{
    public static partial class OrderByRequestExtension
    {
        public static IQueryable<DegreeCourse> OrderByRequest(this IQueryable<DegreeCourse> query, string sortBy, string sortDir)
        {
            return true switch
            {
                _ when IsSortBy(sortBy, nameof(DegreeCourse.DegreeCourseName)) =>
                    IsSortDir(sortDir)
                        ? query.OrderBy(x => x.DegreeCourseName)
                        : query.OrderByDescending(x => x.DegreeCourseName),

                _ => query.OrderBy(x => x.DegreeCourseName)
            };
        }
    }
}