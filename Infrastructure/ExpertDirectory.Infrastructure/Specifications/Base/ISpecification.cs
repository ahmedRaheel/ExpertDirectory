using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpertDirectory.Infrastructure.Specifications.Base
{
    /// <summary>
    ///     ISpecification
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
