using Jwt.Context.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Context.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int SaveChanges();

        void BeginTransaction();

        void Commit();

        void RollBack();
    }
}
