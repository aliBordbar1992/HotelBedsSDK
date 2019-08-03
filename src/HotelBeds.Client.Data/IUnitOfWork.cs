using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBeds.Client.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default);
    }
}