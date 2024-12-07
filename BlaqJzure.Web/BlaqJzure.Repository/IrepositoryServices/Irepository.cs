using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Repository.IrepositoryServices
{
    public interface Irepository<TEntity> where TEntity : class
    {

        Task<TEntity?> Get(object id);

        IQueryable<TEntity> Get();

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            string includeProperties = "");

        IQueryable<TEntity> Where(
            IQueryable<TEntity> query,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            string includeProperties = "");

        Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> expression);

        Task<bool> Create(TEntity entity);

        void CreateMultiple(IEnumerable<TEntity> entities);

        Task<bool> Delete(int id);

        Task<bool> Delete(TEntity entity);

        void DeleteMultiple(List<TEntity> entities);

        Task<bool> Update(TEntity entity);
        IEnumerable<TOutput> ExecuteSqlScripts<TOutput>(string sql);
    }
}
