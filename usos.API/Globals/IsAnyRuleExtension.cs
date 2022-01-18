using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace usos.API.Globals
{
  public static class IsAnyRuleExtension
  {
    public static async Task IsAnyRuleAsync<TSource>(
      this IQueryable<TSource> source,
      Expression<Func<TSource, bool>> predicate,
      CancellationToken cancellationToken = default)
    {
      if(!await source.AnyAsync(predicate, cancellationToken: cancellationToken))
      {
        throw new BusinessNotFoundException( $"{typeof(TSource).Name} was not found");
      }
    }
  }
}