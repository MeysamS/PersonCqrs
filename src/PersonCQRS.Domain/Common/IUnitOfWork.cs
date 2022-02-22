using System;
using System.Threading;
using System.Threading.Tasks;

namespace PersonCQRS.Domain.Common
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}