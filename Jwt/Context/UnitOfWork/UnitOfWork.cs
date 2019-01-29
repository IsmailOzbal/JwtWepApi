using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jwt.Context.GenericRepository;
using System.Data.Entity;

namespace Jwt.Context.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private bool disposed = false;
        private DbContextTransaction transaction = null;
        public UnitOfWork(DatabaseContext context)
        {
            //Database.SetInitializer(new DatabaseInitializer());
            _context = context;
        }

        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}