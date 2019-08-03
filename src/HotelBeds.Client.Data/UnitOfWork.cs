using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelBeds.Client.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var t = Context.ChangeTracker.HasChanges();
            return await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual int SaveChanges() => Context.SaveChanges();

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
            => await Context.Database.ExecuteSqlCommandAsync(sql, parameters, cancellationToken);
    }
}