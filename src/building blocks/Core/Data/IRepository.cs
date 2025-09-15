using Core.DomainObjects;

namespace Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggrgateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
