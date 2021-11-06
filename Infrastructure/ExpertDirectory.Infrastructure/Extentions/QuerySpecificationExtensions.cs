﻿using ExpertDirectory.Infrastructure.Specifications.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExpertDirectory.Infrastructure.Extentions
{
    /// <summary>
    ///    QuerySpecificationExtensions
    /// </summary>
    public static class QuerySpecificationExtensions
    {
        /// <summary>
        ///     Specification
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public static IQueryable<T> Specification<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(query,
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult.Where(spec.Criteria);
        }
    }
}
