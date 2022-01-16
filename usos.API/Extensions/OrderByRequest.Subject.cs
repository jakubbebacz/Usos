using System.Linq;
using usos.API.Entities;

namespace usos.API.Extensions
{
    public static partial class OrderByRequestExtension
    {
        public static IQueryable<Subject> OrderByRequest(this IQueryable<Subject> query, string sortBy, string sortDir)
        {
            return true switch
            {
                _ when IsSortBy(sortBy, nameof(Subject.SubjectName)) =>
                    IsSortDir(sortDir)
                        ? query.OrderBy(x => x.SubjectName)
                        : query.OrderByDescending(x => x.SubjectName),

                _ => query.OrderBy(x => x.SubjectName)
            };
        }
    }
}