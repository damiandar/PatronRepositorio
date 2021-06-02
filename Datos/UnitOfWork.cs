using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public interface IUnitOfWork : IDisposable
    {
        ComercioDbContext Context { get; }
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public ComercioDbContext Context { get; }

        public UnitOfWork(ComercioDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
