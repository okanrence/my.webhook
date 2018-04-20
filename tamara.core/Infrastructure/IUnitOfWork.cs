using System;

namespace tamara.core.infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }

    internal class UnitOfWork : IUnitOfWork
    {
        private TamaraDBContext _Context = new TamaraDBContext();
        internal TamaraDBContext Context { get { return this._Context; } }

        public int SaveChanges()
        {
            return this._Context.SaveChanges();
        }

        public void Dispose()
        {
            this._Context.Dispose();
        }
    }
}
