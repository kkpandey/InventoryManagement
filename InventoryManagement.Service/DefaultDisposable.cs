using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service
{
    public abstract class DefaultDisposable : IDisposable
    {
        protected readonly WebAppDBContext db;

        private bool _disposed;
        private readonly object _disposeLock = new object();
        protected DefaultDisposable()
        {
            db = new WebAppDBContext();
            
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }

                    _disposed = true;
                }
            }
        }
    }
}
