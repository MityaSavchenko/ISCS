using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ISCS.Infrastructure
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> AsTracking<T>(this IQueryable<T> set, bool tracking)
            where T : class => tracking ? set : set.AsNoTracking();

        public static IQueryable<T> Include<T>(this IQueryable<T> set, bool tracking, params Expression<Func<T, object>>[] includeProperties)
            where T : class
        {

            if (includeProperties != null)
            {
                set = includeProperties.Aggregate(set,
                    (current, include) => current.Include(include));
            }

            return set;
        }
    }
}
