using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
using IoasysChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IoasysChallenge.Infrastructure.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ImdbContext _repository;
        internal DbSet<TEntity> _dbSet;

        public EFRepository(ImdbContext repository)
        {
            _repository = repository;
            _dbSet = _repository.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            await _repository.Set<TEntity>().AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }

        public IQueryable<TEntity> FindAll()
        {
            return _repository.Set<TEntity>().AsQueryable();
        }

        public async Task Update(TEntity entity)
        {
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<TEntity> GetByName(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).SingleOrDefaultAsync();
        }
    }
}
