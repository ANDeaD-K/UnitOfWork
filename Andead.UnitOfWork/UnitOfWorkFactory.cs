using System;
using Andead.UnitOfWork.Interfaces;

namespace Andead.UnitOfWork
{
    public class UnitOfWorkFactory<T> : IUnitOfWorkFactory<T> where T : UnitOfWork
    {
        private readonly object[] _arguments;

        public UnitOfWorkFactory(params object[] arguments)
        {
            _arguments = arguments;
        }

        public IUnitOfWork Create()
        {
            return (T)Activator.CreateInstance(typeof(T), _arguments);
        }
    }
}
