namespace Andead.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkFactory<T> where T : UnitOfWork
    {
        IUnitOfWork Create();
    }
}
