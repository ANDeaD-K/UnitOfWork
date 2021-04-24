using System.Linq;
using Andead.UnitOfWork.Interfaces;

namespace Andead.UnitOfWork
{
    public class QueryBuilder<T> : IQueryBuilder<T> where T : class
    {
        protected IQueryable<T> Query { get; }

        public QueryBuilder(IQueryable<T> query)
        {
            Query = query;
        }

        public IQueryable<T> GetQuery()
        {
            return Query;
        }

        public IQueryBuilder<T> Condition(ISpecification<T> specification)
        {
            return new QueryBuilder<T>(Query.Where(specification.SatisfiedBy()));
        }

        public T[] ToArray()
        {
            return Query.ToArray();
        }
    }
}
