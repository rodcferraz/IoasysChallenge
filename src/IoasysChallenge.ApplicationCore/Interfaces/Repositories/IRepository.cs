using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        //Task<Tentity> GetById(int id);
        IQueryable<TEntity> FindAll();
        Task<TEntity> GetByName(Expression<Func<TEntity, bool>> predicate);
    }
}
