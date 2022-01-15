using System.Linq;
using usos.API.Entities;

namespace usos.API.Extensions
{
    public static partial class OrderByRequestExtension
    {
        public static IQueryable<Advert> OrderByRequest(this IQueryable<Advert> query, string sortBy, string sortDir)
        {
            return true switch
            {
                _ when IsSortBy(sortBy, nameof(Advert.Date)) =>
                    IsSortDir(sortDir)
                        ? query.OrderBy(x => x.Date)
                        : query.OrderByDescending(x => x.Date),

                _ => query.OrderByDescending(x => x.Date)
            };
        }
    }
}