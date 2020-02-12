using System;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        void Complete();
    }
}
