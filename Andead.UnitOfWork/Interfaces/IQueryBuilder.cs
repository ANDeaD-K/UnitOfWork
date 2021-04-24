namespace Andead.UnitOfWork.Interfaces
{
    public interface IQueryBuilder<T> where T : class
    {
        IQueryBuilder<T> Condition(ISpecification<T> specification);
        T[] ToArray();
    }
}
