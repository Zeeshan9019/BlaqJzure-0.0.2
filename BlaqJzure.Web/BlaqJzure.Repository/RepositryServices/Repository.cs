using BlaqJzure.Repository.IrepositoryServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Repository.RepositryServices
{
    public class Repository<TEntity> : Irepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _databaseContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext databaseContext)
        {
            this._databaseContext = databaseContext;
            _dbSet = databaseContext.Set<TEntity>();
        }

        public virtual async Task<TEntity?> Get(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity?> GetMemrerByUsername(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual IQueryable<TEntity> Get()
        {
            IQueryable<TEntity> query = _dbSet;
            return query;
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null) query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                         (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
            {
                query = orderBy(query);

                if (skip.HasValue) query = query.Skip(skip.Value);

                if (take.HasValue) query = query.Take(take.Value);
            }

            return query;
        }

        public virtual IQueryable<TEntity> Where(IQueryable<TEntity> query,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            string includeProperties = "")
        {
            foreach (var includeProperty in includeProperties.Split
                         (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
            {
                query = orderBy(query);

                if (skip.HasValue) query = query.Skip(skip.Value);

                if (take.HasValue) query = query.Take(take.Value);
            }

            return query;
        }

        public virtual async Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public virtual async Task<bool> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return await SaveChanges();
        }

        public virtual void CreateMultiple(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                return await Delete(entity);
            }
            return false;
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            if (_databaseContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            return await SaveChanges();
        }

        public virtual void DeleteMultiple(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _databaseContext.Entry(entity).State = EntityState.Modified;
            return await SaveChanges();
        }

        public virtual IEnumerable<TOutput> ExecuteSqlScripts<TOutput>(string sql)
        {
            var result = _dbSet.FromSqlRaw(sql).ToList();
            return (IEnumerable<TOutput>)result;
        }

        private async Task<bool> SaveChanges()
        {
            return await _databaseContext.SaveChangesAsync() > 0;
        }
    }
}
