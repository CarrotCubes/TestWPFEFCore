using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace TestWPFEFCore.Repository
{
    public interface IRespository<TEntity> where TEntity : class
    {
        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                              Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                              bool disableTracking = true,
                                              bool ignoreQueryFilters = false);

        TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                         bool disableTracking = true,
                                         bool ignoreQueryFilters = false);

        Task<List<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                   bool disableTracking = true,
                                   bool ignoreQueryFilters = false);

        int Add(TEntity entity);

        Task<int> AddAsync(TEntity entity);

        int Update(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);
    }
}
