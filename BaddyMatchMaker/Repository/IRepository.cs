using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(int id);

        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);

        void Insert(TEntity entity);

        void Delete(int id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}
