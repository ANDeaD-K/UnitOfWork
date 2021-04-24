using System;
using Andead.UnitOfWork.Interfaces;

namespace Andead.UnitOfWork
{
    public class UnitOfWorkFactory<T> : IUnitOfWorkFactory<T> where T : UnitOfWork
    {
        public IUnitOfWork Create()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
