using System.Linq;
using usos.API.Entities;

namespace usos.API.Extensions
{
    public static partial class OrderByRequestExtension
    {
        public static IQueryable<Student> OrderByRequest(this IQueryable<Student> query, string sortBy, string sortDir)
        {
            return true switch
            {
                _ when IsSortBy(sortBy, nameof(Student.Email)) =>
                    IsSortDir(sortDir)
                        ? query.OrderBy(x => x.Email)
                        : query.OrderByDescending(x => x.Email),
        
                _ when IsSortBy(sortBy, nameof(Student.FirstName)) =>
                    IsSortDir(sortDir)
                        ? query.OrderBy(x => x.FirstName).ThenBy(x => x.Surname)
                        : query.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.Surname),
        
                _ when IsSortBy(sortBy, nameof(Student.Surname)) =>
                    IsSortDir(sortDir)
                        ? query.OrderBy(x => x.Surname).ThenBy(x => x.FirstName)
                        : query.OrderByDescending(x => x.Surname).ThenByDescending(x => x.FirstName),

                _ => query.OrderByDescending(x => x.Surname)
            };
        }
    }
}