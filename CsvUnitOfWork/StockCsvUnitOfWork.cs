using StandardInterfaces;
using System;

namespace CsvUnitOfWork
{
    public class CsvUnitOfWork<TEntity> : IUnitOfWork where TEntity : class
    {
        private readonly CsvContext<TEntity> _context;
        public CsvRepo<TEntity> Repo;
        private bool _disposed = false;
        public CsvUnitOfWork(CsvContext<TEntity> context)
        {
            _context = context;
            Repo = new CsvRepo<TEntity>(context);
        }
        public void Complete()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(CsvUnitOfWork<TEntity>));
                _context.SaveChanges();
        }
        public void Dispose()
        {
            _disposed = true;
        }
    }
}
