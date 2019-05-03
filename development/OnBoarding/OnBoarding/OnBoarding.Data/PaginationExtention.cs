namespace OnBoarding.Data
{
    using OnBoarding.Contract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class PaginationExtention
    {
        public static IList<T> Paginate<T>(this IQueryable<T> query, PageRequest pageRequest) where T : class
        {
            return query.ApplyWhere(pageRequest.SearchParams).ApplyOrderBy(pageRequest.SortColumns).Skip((pageRequest.PageNumber - 1) * pageRequest.PerPageCount).Take(pageRequest.PerPageCount).ToList();
        }

        public static int TotalCount<T>(this IQueryable<T> query, PageRequest pageRequest) where T : class
        {
            return query.ApplyWhere(pageRequest.SearchParams).Count();
        }

        private static IOrderedQueryable<T> ApplyOrderBy<T>(this IQueryable<T> source, Dictionary<string, bool> orderParams)
        {
            var result = (IOrderedQueryable<T>)source;
            var param = Expression.Parameter(typeof(T), string.Empty);
            for (int i = 0; i < orderParams.Count; i++)
            {
                var property = Expression.PropertyOrField(param, orderParams.ElementAt(i).Key);
                var sort = Expression.Lambda(property, param);

                var call = Expression.Call(
                    typeof(Queryable),
                    (i == 0 ? "OrderBy" : "ThenBy") + (orderParams.ElementAt(i).Value ? "Descending" : string.Empty),
                    new[] { typeof(T), property.Type },
                    source.Expression,
                    Expression.Quote(sort));

                result = (IOrderedQueryable<T>)result.Provider.CreateQuery<T>(call);
            }
            return result;
        }

        public static IQueryable<T> ApplyWhere<T>(this IQueryable<T> source, Dictionary<string, string> searchParams) where T : class
        {
            if(searchParams == null)
            {
                return source;
            }

            var result = source;
            searchParams.ToList().ForEach(paramInfo =>
            {
                result = result.ApplyWhere(paramInfo.Key, paramInfo.Value);
            });
            return result;
        }

        public static IQueryable<T> ApplyWhere<T>(this IQueryable<T> source, string propertyName, object propertyValue) where T : class
        {
            var mba = PropertyAccessorCache<T>.Get(propertyName);
            if (mba == null) return source;

            object value;
            try
            {
                value = Convert.ChangeType(propertyValue, mba.ReturnType);
            }
            catch (SystemException ex) when (
                ex is InvalidCastException ||
                ex is FormatException ||
                ex is OverflowException ||
                ex is ArgumentNullException)
            {
                return source;
            }

            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var expressionValue = Expression.Constant(propertyValue, typeof(string));
            var containsMethodExp = Expression.Call(mba.Body, method, expressionValue);
            
            var expression = Expression.Lambda(containsMethodExp, mba.Parameters[0]);

            var resultExpression = Expression.Call(
                null,
                GetMethodInfo(Queryable.Where, source, (Expression<Func<T, bool>>)null),
                new Expression[] { source.Expression, Expression.Quote(expression) });
            return source.Provider.CreateQuery<T>(resultExpression);
        }

        private static MethodInfo GetMethodInfo<T1, T2, T3>(
            Func<T1, T2, T3> f,
            T1 unused1,
            T2 unused2)
        {
            return f.Method;
        }
    }

    public static class PropertyAccessorCache<T> where T : class
    {
        private static readonly IDictionary<string, LambdaExpression> _cache;

        static PropertyAccessorCache()
        {
            var storage = new Dictionary<string, LambdaExpression>();

            var t = typeof(T);
            var parameter = Expression.Parameter(t, "p");
            foreach (var property in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var lambdaExpression = Expression.Lambda(propertyAccess, parameter);
                storage[property.Name] = lambdaExpression;
            }

            _cache = storage;
        }

        public static LambdaExpression Get(string propertyName)
        {
            return _cache.TryGetValue(propertyName, out LambdaExpression result) ? result : null;
        }
    }
}

